using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Acklann.Poshley
{
    public static class Helper
    {
        public static string ToJson(this Argument arg, bool showType = false)
        {
            var json = new JObject(
                new JProperty("position", arg.Position),
                new JProperty("name", string.Join(", ", arg.Aliases?? new string[0])));

            if (!string.IsNullOrEmpty(arg.Description)) json.Add(new JProperty("description", arg.Description));
            if (arg.DataType != null && (arg.Default != null || arg.Value != null || showType)) json.Add(new JProperty("type", arg.DataType.Name));
            if (arg.Value != null) json.Add(new JProperty("value", arg.Value));
            if (arg.Default != null) json.Add(new JProperty("default", arg.Default));
            if (arg.IsRequired) json.Add(new JProperty("require", arg.IsRequired));

            return json.ToString(Formatting.Indented);
        }

        public static string ToJson(this CommandInfo command, bool showType = false)
        {
            var json = new JObject();
            json.Add(new JProperty("verb", command.Name));

            var arguments = new JArray();
            json.Add(new JProperty("args", arguments));
            foreach (Argument arg in command)
            {
                arguments.Add(JObject.Parse(ToJson(arg, showType)));
            }

            if (command.Examples.Count > 0)
            {
                var examples = new JArray();
                json.Add(new JProperty("examples", examples));
                foreach (var eg in command.Examples)
                {
                    examples.Add(new JObject(
                        new JProperty("command", eg.Command),
                        new JProperty("description", eg.Description)
                        ));
                }
            }

            if (command.RelatedLinks.Count > 0)
            {
                var links = new JArray();
                json.Add(new JProperty("relatedLinks", links));
                foreach (var link in command.RelatedLinks)
                {
                    links.Add(link);
                }
            }

            return json.ToString(Formatting.Indented);
        }
    }
}