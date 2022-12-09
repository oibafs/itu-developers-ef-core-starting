using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Sample.Data;

namespace Sample.Samples;

public static class SampleInjection
{
    public static void Run()
    {
        Console.WriteLine("Provide an UserID:");
        var id = Console.ReadLine();
        Console.WriteLine("Provide the new name:");
        var newName = Console.ReadLine();

        using(var context = new MainContext())
        {
            //Wrong
            var sql = $"update Users set Name = '{newName}' where Id = '{id}'";
            Console.WriteLine(sql);
            context.Database.ExecuteSqlRaw(sql);

            //Right
            // var sql = "update Users set Name = @NewName where Id = @Id";
            // var parameters = new SqlParameter[] {
            //     new SqlParameter("@NewName", newName),
            //     new SqlParameter("@Id", id)
            // };
            // context.Database.ExecuteSqlRaw(sql, parameters);
        }
    }
}
