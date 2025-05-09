using Microsoft.EntityFrameworkCore;
using TravelList.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    public DbSet<Airline> Airlines { get; set; }
    public DbSet<Vacation> Vacations { get; set; }
    public DbSet<Message> Messages { get; set; }

}
