using Microsoft.EntityFrameworkCore;

namespace SillyStringzFactory.Models
{
  public class SillyStringzFactoryContext : DbContext
  {
    public DbSet<Engineer> Engineers { get; set; }
    public DbSet<Machine> Machines { get; set; }
    public DbSet<EngineerMachine> EngineerMachines { get; set; }
    public SillyStringzFactoryContext(DbContextOptions options) : base(options) { }
  }
}