using BenchmarkDotNet.Attributes;
using Sample.Data;

namespace Sample.Benchmarks;

[MemoryDiagnoser]
public class ToListBenchmarker
{
    [Benchmark]
    public void FindDataWithCorrectToList()
    {
        using(var context = new MainContext())
        {
            var usersFromBrazil = context.Users.Where(u => u.Country == "Brazil").ToList();
        }
    }

    [Benchmark]
    public void FindDataWithIncorrectToList()
    {
        using(var context = new MainContext())
        {
            var usersFromBrazil = context.Users.ToList().Where(u => u.Country == "Brazil");
        }
    }
}
