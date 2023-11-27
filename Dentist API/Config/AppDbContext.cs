using Dentist_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Dentist_API.Config;

public class AppDbContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=Dentist;Username=postgres;Password=123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(u=>u.Gender);
    }

    private DbSet<User> Users { get; set; }
    private DbSet<Gender> Genders { get; set; }
}