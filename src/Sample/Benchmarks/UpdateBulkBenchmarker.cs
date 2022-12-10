using BenchmarkDotNet.Attributes;

using Microsoft.EntityFrameworkCore;

using Sample.Data;

namespace Sample.Benchmarks;

[MemoryDiagnoser]
public class UpdateBulkBenchmarker
{
    [Benchmark]
    public async Task ExecuteUpdateCommon()
    {
        using(var context = new MainContext())
        {
            var entities = await context.Users.Where(u => u.Country == "Brazil").ToListAsync();
            entities.ForEach(e => e.Name = DateTime.Now.ToString());

            context.UpdateRange(entities);

            await context.SaveChangesAsync();
        }
    }

    [Benchmark]
    public async Task ExecuteUpdateBulk()
    {
        using(var context = new MainContext())
        {
            await context.Users.Where(u => u.Country == "Brazil")
                .ExecuteUpdateAsync(x => x.SetProperty(p => p.Name, p => DateTime.Now.ToString()));
        }
    }
}
