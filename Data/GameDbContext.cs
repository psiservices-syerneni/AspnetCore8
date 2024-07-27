using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GameStore;

public class GameDbContext : DbContext
{
    public GameDbContext(DbContextOptions<GameDbContext> options) : base(options) { }
   
    public DbSet<Game> Games => Set<Game>();
    public DbSet<Genre> Genres => Set<Genre>();

}


 public class DatabaseDesignTimeDbContextFactory
  : IDesignTimeDbContextFactory<GameDbContext>
{
     public GameDbContext CreateDbContext(string[] args)
   {
       var builder = new DbContextOptionsBuilder<GameDbContext>();
       builder.UseSqlite();
     return new GameDbContext(builder.Options);
  }
  
   }
