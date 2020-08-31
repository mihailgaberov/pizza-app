using Microsoft.EntityFrameworkCore;

namespace backend {
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    public DbSet<PizzaVotes> PizzaVotes { get; set; }
  }
}