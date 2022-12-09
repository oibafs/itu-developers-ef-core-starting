using Sample.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Sample.Data;

public sealed class MainContext : DbContext
{
    private string _connectionString;

    public DbSet<User> Users { get; set; } = default!;

    public DbSet<UserMapped> UsersMapped { get; set; } = default!;

    public MainContext()
    {
        _connectionString = "Data Source=localhost,1433;Initial Catalog=ItuDevelopers;User ID=sa;Password=Pass@word;TrustServerCertificate=true;";
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(_connectionString);
    }
}
