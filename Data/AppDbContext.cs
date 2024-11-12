using Jornada.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Jornada.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Feedback> Feedbacks { get; set; }

}
