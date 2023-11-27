using Microsoft.EntityFrameworkCore;

namespace Dentist_API.Config;

public class AppDbContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=Dentist;Username=postgres;Password=123");
}