using BenchmarkDotNet.Attributes;

using Microsoft.EntityFrameworkCore;

using Sample.Data;

namespace Sample.Benchmarks;

[MemoryDiagnoser]
public class DeleteBulkBenchMarker
{
    [Benchmark]
    public async Task ExecuteDeleteCommon()
    {
        using(var context = new MainContext())
        {
            var entities = await context.Users.Where(u => u.Country == "Brazil").Take(100).ToListAsync();
            entities.ForEach(e => context.Entry(e).State = EntityState.Deleted);

            await context.SaveChangesAsync();
        }
    }

    [Benchmark]
    public async Task ExecuteDeleteBulk()
    {
        using(var context = new MainContext())
        {
            await context.Users.Where(u => u.Country == "Brazil").Take(100).ExecuteDeleteAsync();
        }
    }
}
