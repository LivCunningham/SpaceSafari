using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SpaceSafari
{
  public partial class Space_SafariContext : DbContext
  {
    public Space_SafariContext()
    {
    }

    public Space_SafariContext(DbContextOptions<Space_SafariContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseNpgsql("server=localhost;database=Space_Safari;User Id=postgres;Password=Squeakyunicorn1");
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");
    }
    public DbSet<Races> AlienTypes { get; set; }
  }
}
