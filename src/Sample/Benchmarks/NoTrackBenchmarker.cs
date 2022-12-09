using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using Sample.Data;

namespace Sample.Benchmarks;

[MemoryDiagnoser]
public class NoTrackBenchmarker
{
    [Benchmark]
    public void FindDataWithoutNoTrack()
    {
        using(var context = new MainContext())
        {
            var usersFromBrazil = context.Users.Where(u => u.Country == "Brazil").ToList();
        }
    }

    [Benchmark]
    public void FindDataWithNoTrack()
    {
        using(var context = new MainContext())
        {
            var usersFromBrazil = context.Users.AsNoTracking().Where(u => u.Country == "Brazil").ToList();
        }
    }

    [Benchmark]
    public void AllDataWithoutNoTrack()
    {
        using(var context = new MainContext())
        {
            var users = context.Users.ToList();
        }
    }

    [Benchmark]
    public void AllDataWithNoTrack()
    {
        using(var context = new MainContext())
        {
            var users = context.Users.AsNoTracking().ToList();
        }
    }
}
