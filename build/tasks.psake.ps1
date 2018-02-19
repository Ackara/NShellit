# SYNOPSIS: This is a psake task file.
Properties {
	# Constants
	$RootDir = "$(Split-Path $PSScriptRoot -Parent)";
	$ManifestJson = "$PSScriptRoot\manifest.json";
	$SecretsJson = "$PSScriptRoot\secrets.json";
	$ArtifactsDir = "$RootDir\artifacts";
	$PoshModulesDir = "";

	# Args
	$SkipCompilation = $false;
	$CommitChanges = $false;
	$Configuration = "";
	$Secrets = @{ };
	$Major = $false;
	$Minor = $false;
	$Branch = "";
}

Task "default" -depends @("restore", "compile", "test");
Task "deploy" -alias "push" -depends @("restore", "version", "compile", "test", "pack", "publish");

#region ----- COMPILATION -----

Task "Import-Dependencies" -alias "restore" -description "This task imports all dependencies." `
-action {
	#  Importing all required powershell modules.
	foreach ($moduleId in @("Buildbox"))
	{
		$modulePath = "$PoshModulesDir\$moduleId\*\*.psd1";
		if (-not (Test-Path $modulePath))
		{
			Save-Module $moduleId -Path $PoshModulesDir;
		}
		Import-Module $modulePath -Force;
		Write-Host "   * imported the '$moduleId.$(Split-Path (Get-Item $modulePath).DirectoryName -Leaf)' powershell module.";
	}

	# Saving $Secrets to a file if available.
	if ((-not (Test-Path $SecretsJson)) -and $Secrets.Count -gt 0)
	{
		$Secrets | ConvertTo-Json | Out-File $SecretsJson -Encoding utf8;
		Write-Host "   * Added '$(Split-Path $SecretsJson -Leaf)' to project.";
	}

	# Creating a new manifest if not available.
	if (-not (Test-Path $ManifestJson))
	{
		New-BuildboxManifest $ManifestJson | Out-Null;
		Write-Host "   * Added '$(Split-Path $ManifestJson -Leaf)' to project.";
	}
}

Task "Increment-VersionNumber" -alias "version" -description "This task increments the project's version numbers" `
-depends @("restore") -action {
	$result = Get-BuildboxManifest $ManifestJson | Update-ProjectManifests "$RootDir\src" -Break:$Major -Feature:$Minor -Patch -Tag -Commit:$CommitChanges;

	Write-Host "   * Incremented version number from '$($result.OldVersion)' to '$($result.Version)'.";
	foreach ($file in $result.ModifiedFiles)
	{
		Write-Host "     * Updated $(Split-Path $file -Leaf).";
	}
}

Task "Build-Solution" -alias "compile" -description "This task compiles the solution." `
-depends @("restore") -precondition { return (-not $SkipCompilation); } -action {
	Write-LineBreak "dotnet: msbuild";
	Exec { &dotnet msbuild $((Get-Item "$RootDir\*.sln").FullName) "/p:Configuration=$Configuration" "/verbosity:minimal"; }
}

Task "Run-Tests" -alias "test" -description "This task invoke all tests within the 'tests' folder." `
-depends @("restore") -action {
	Push-Location $RootDir;
	try
	{
		# Running all MSTest tests.
		foreach ($testFile in (Get-ChildItem "$RootDir\tests\*\bin\$Configuration" -Recurse -Filter "*$(Split-Path $RootDir -Leaf)*test*.dll"))
		{
			Write-LineBreak "dotnet: vstest";
			Exec { &dotnet vstest $testFile.FullName; }
		}

		# Running all Pester tests.
		$testsFailed = 0;
		foreach ($testFile in (Get-ChildItem "$RootDir\tests\*\" -Recurse -Filter "*tests.ps1"))
		{
			Write-LineBreak "pester";
			$results = Invoke-Pester -Script $testFile.FullName -PassThru;
			$testsFailed += $results.FailedCount;
		}
		if ($testsFailed -ge 1) { throw "FAILED $testsFailed Pester tests."; }
	}
	finally { Pop-Location; }
}

#endregion

#region ----- PUBLISHING -----

Task "Generate-Packages" -alias "pack" -description "This task generates the app delployment packages." `
-depends @("restore") -action {
	if (Test-Path $ArtifactsDir) { Remove-Item $ArtifactsDir -Recurse -Force; }
	New-Item $ArtifactsDir -ItemType Directory | Out-Null;
	
	$version = Get-Version;
	$proj = Get-Item "$RootDir\src\*\*.csproj";
	Write-LineBreak "dotnet: pack '$($proj.BaseName)'";
	Exec { &dotnet pack $proj.FullName --output "$ArtifactsDir\nuget" --configuration $Configuration /p:PackageVersion=$version; }
}

Task "Publish-Application" -alias "publish" -description "This task publish all app packages to their respective host." `
-depends @("pub-nuget");

Task "Publish-NuGetPackages" -alias "pub-nuget" -description "This task publish all .nupkg files to nuget.org." `
-depends @("restore") -action {
	Assert (Test-Path $ArtifactsDir) "No packages found; run the 'pack' task then try again.";

	foreach ($nupkg in Get-ChildItem $ArtifactsDir -Recurse -Filter "*.nupkg")
	{
		Write-Host "   * published '$($nupkg.Name)' to nuget.org";
		Write-Warning "NOT Implemented";
	}
}

#endregion

#region ----- FUNCTIONS -----

function Get-Manifest()
{
	return Get-Content $ManifestJson | Out-String | ConvertFrom-Json;
}

function Get-Version()
{
	$manifest = Get-BuildboxManifest;
	$suffix = $manifest | Get-VersionSuffix $Branch;
	if (-not [string]::IsNullOrEmpty($suffix)) {  $suffix = "-$suffix"; }
	return "$($manifest.Version.ToString())$suffix";
}

function Get-Secret([string]$key)
{
	$value = $Secrets.$key;
	if ([string]::IsNullOrEmpty($value))
	{
		$value = Get-Content $SecretsJson | Out-String | ConvertFrom-Json | Select-Object -ExpandProperty $key;
	}
	return $value;
}

#endregion

$seperator = "----------------------------------------------------------------------";
FormatTaskName "$seperator`r`n  {0}`r`n$seperator";