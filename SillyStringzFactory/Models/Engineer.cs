
using System.Collections.Generic;

namespace SillyStringzFactory.Models
{
  public class Engineer
  {
    public int EngineerId { get; set; }
    public string Name { get; set; }
    public List<Machine> Machines { get; set; }
       public List<EngineerMachine> EngineerMachines { get; }
  }
}