using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SillyStringzFactory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SillyStringzFactory.Controllers
{
  public class EngineersController : Controller
  {
    private readonly SillyStringzFactoryContext _db;

    public EngineersController(SillyStringzFactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Engineer> model = _db.Engineers.ToList();
      return View(model);
    }
     public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Engineer engineer)
    {
      _db.Engineers.Add(engineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

     public ActionResult Details(int id)
    {
      Engineer thisEngineer = _db.Engineers
                                  .Include(engineer => engineer.EngineerMachines)
                                  .ThenInclude(join => join.Machine)
                                  .FirstOrDefault(engineer => engineer.EngineerId == id);
      return View(thisEngineer);
    }
     public ActionResult AddMachine(int id)
    {
      Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult AddMachine(Engineer engineer, int machineId)
    {
#nullable enable
      EngineerMachine? joinEntity = _db.EngineerMachines.FirstOrDefault(join => (join.MachineId == machineId && join.EngineerId == engineer.EngineerId));
#nullable disable
      if (joinEntity == null && machineId != 0)
      {
        _db.EngineerMachines.Add(new EngineerMachine() { MachineId = machineId, EngineerId = engineer.EngineerId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = engineer.EngineerId });
    }
      public ActionResult Edit(int id)
    {
      Engineer thisEngineer = _db.Engineers
                              .Include(engineer => engineer.EngineerMachines)
                              .ThenInclude(join => join.Machine)
                              .FirstOrDefault(engineer => engineer.EngineerId == id);
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult Edit(Engineer engineer)
    {
      _db.Engineers.Update(engineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
        public ActionResult DeleteMachine(int id)
    {
      EngineerMachine joinEntity = _db.EngineerMachines.FirstOrDefault(engineer => engineer.EngineerId == id);
      Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == joinEntity.MachineId);
      ViewBag.MachineName = thisMachine.Name;
      return View(joinEntity);
    }

    [HttpPost, ActionName("DeleteMachine")]
    public ActionResult DeleteConfirmed(int id)
    {
      EngineerMachine joinEntity = _db.EngineerMachines.FirstOrDefault(entity => entity.EngineerMachineId == id);
      _db.EngineerMachines.Remove(joinEntity);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}