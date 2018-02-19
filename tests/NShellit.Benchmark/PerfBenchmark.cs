using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acklann.Poshly
{
    [OrderProvider(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn(BenchmarkDotNet.Mathematics.NumeralSystem.Roman)]
    public class PerfBenchmark
    {
        [Benchmark(Description = "")]
        public void foo()
        {

        }
    }
}
