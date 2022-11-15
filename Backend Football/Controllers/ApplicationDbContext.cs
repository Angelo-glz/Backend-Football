using Backend_Football.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_Football
{
  public class ApplicationDbContext: DbContext
  {

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {

    }

    public DbSet<Player> Players { get; set; }
  }
}
