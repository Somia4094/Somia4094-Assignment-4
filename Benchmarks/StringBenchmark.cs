using BenchmarkDotNet.Attributes;
using System.Text;

[MemoryDiagnoser]
public class StringBenchmark
{
    [Params(100, 1000, 10000, 100000)]
    public int Iterations;

    [Benchmark]
    public void StringConcatenation()
    {
        string result = "";

        for (int i = 0; i < Iterations; i++)
        {
            result += "C# Basics";
        }
    }

    [Benchmark]
    public void StringBuilderConcatenation()
    {
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < Iterations; i++)
        {
            result.Append("C# Basics");
        }
    }
}