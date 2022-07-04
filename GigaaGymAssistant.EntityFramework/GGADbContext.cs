using GigaaGymAssistant.Infrastructure.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GigaaGymAssistant.Infrastructure.EntityFramework;

public class GGADbContext : DbContext
{
    private readonly IConfiguration _config;
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    public GGADbContext(IConfiguration config)
    {
        _config = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .Property(u => u.Email)
            .IsRequired();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
    }
}