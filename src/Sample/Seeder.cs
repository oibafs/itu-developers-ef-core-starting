using Sample.Data;
using Sample.Data.Entities;
using Bogus;

namespace Sample;

public static class Seeder
{
    public static void LoadSampleData(MainContext context)
    {
        if (!context.Users.Any())
        {

            Console.WriteLine("Loading sample data");

            var fakerUser = new Faker<User>()
                .RuleFor(p => p.Id, f => Guid.NewGuid())
                .RuleFor(p => p.Name, f => f.Name.FullName())
                .RuleFor(p => p.Email, f => f.Internet.Email())
                .RuleFor(p => p.Country, f => f.Address.Country())
                .RuleFor(p => p.Bio, f => f.Lorem.Paragraphs(3));

            var sampleData = fakerUser.Generate(100000);

            foreach (var data in sampleData)
            {
                context.Users.Add(data);
            }

            context.SaveChanges();
        }

        if (!context.UsersMapped.Any())
        {

            var fakerUserMapped = new Faker<UserMapped>()
                .RuleFor(p => p.Id, f => Guid.NewGuid())
                .RuleFor(p => p.Name, f => f.Name.FullName())
                .RuleFor(p => p.Email, f => f.Internet.Email())
                .RuleFor(p => p.Country, f => f.Address.Country())
                .RuleFor(p => p.Bio, f => f.Lorem.Paragraphs(3));

            var sampleDataMapped = fakerUserMapped.Generate(100000);

            foreach (var data in sampleDataMapped)
            {
                context.UsersMapped.Add(data);
            }

            context.SaveChanges();

            Console.WriteLine("Sample data loaded!");
        }
    }
}
