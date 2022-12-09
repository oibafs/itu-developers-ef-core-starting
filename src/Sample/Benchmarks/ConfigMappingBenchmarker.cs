using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using Sample.Data;

namespace Sample.Benchmarks;

[MemoryDiagnoser]
public class ConfigMappingBenchmarker
{
    [Benchmark]
    public void FindUsers()
    {
        using (var context = new MainContext())
        {
            var usersFromBrazil = context.Users.Where(u => u.Country == "Brazil").ToList();
        }
    }

    [Benchmark]
    public void FindUsersNoTrack()
    {
        using (var context = new MainContext())
        {
            var usersFromBrazil = context.Users.AsNoTracking().Where(u => u.Country == "Brazil").ToList();
        }
    }

    [Benchmark]
    public void FindUsersMapped()
    {
        using (var context = new MainContext())
        {
            var usersFromBrazil = context.UsersMapped.Where(u => u.Country == "Brazil").ToList();
        }
    }

    [Benchmark]
    public void FindUsersMappedNoTrack()
    {
        using (var context = new MainContext())
        {
            var usersFromBrazil = context.UsersMapped.AsNoTracking().Where(u => u.Country == "Brazil").ToList();
        }
    }

    [Benchmark]
    public void AllUsers()
    {
        using (var context = new MainContext())
        {
            var users = context.Users.ToList();
        }
    }

    [Benchmark]
    public void AllUsersNoTrack()
    {
        using (var context = new MainContext())
        {
            var users = context.Users.AsNoTracking().ToList();
        }
    }

    [Benchmark]
    public void AllUsersMapped()
    {
        using (var context = new MainContext())
        {
            var users = context.UsersMapped.ToList();
        }
    }

    [Benchmark]
    public void AllUsersMappedNoTrack()
    {
        using (var context = new MainContext())
        {
            var users = context.UsersMapped.AsNoTracking().ToList();
        }
    }
}
