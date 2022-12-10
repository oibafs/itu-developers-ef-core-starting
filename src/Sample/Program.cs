using Sample.Data;
using BenchmarkDotNet.Running;
using Sample.Benchmarks;
using Sample.Samples;

namespace Sample;

public class Program
{
    static void Main(string[] args)
    {
        using(var context = new MainContext())
        {
            Seeder.LoadSampleData(context);
        }        

        //1 - ToList
        //var summary = BenchmarkRunner.Run<ToListBenchmarker>();

        //2 - AsNoTracking
        //var summary = BenchmarkRunner.Run<NoTrackBenchmarker>();

        //3 - MapColumns Properly
        //var summary = BenchmarkRunner.Run<ConfigMappingBenchmarker>();

        //4 - SQL Injection
        //SampleInjection.Run();

        //5 - EF 7 - Bulk Delete
        // var summary = BenchmarkRunner.Run<DeleteBulkBenchMarker>();

        //6 - EF 7 - Bulk Update
        var summary = BenchmarkRunner.Run<UpdateBulkBenchmarker>();
    }
}