using Dentist_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Dentist_API.Config;

public class AppDbContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=Dentist;Username=postgres;Password=123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Gender>().HasData(
            new Gender
            {
                Id = 1,
                GenderName = "Male"
            },
            new Gender
            {
                Id = 2,
                GenderName = "Female"
            });
        modelBuilder.Entity<User>()
            .HasOne(u=>u.Gender);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Gender> Genders { get; set; }
}