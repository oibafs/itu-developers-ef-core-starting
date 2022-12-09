using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RealWorldSample.Domain.Entities;

namespace RealWorldSample.Infrastructure.Data;

public sealed class MainContext : DbContext
{
    public DbSet<User> Users { get; set; } = default!;

    public MainContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
