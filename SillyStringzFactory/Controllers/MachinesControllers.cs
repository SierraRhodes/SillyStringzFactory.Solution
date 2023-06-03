using Microsoft.AspNetCore.Mvc;
using SillyStringzFactory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SillyStringzFactory.Controllers
{
  public class MachinesController : Controller
  {
    private readonly SillyStringzFactoryContext _db;

    public MachinesController(SillyStringzFactoryContext db)
    {
      _db = db;
    }

  public ActionResult Index()
{
  List<Machine> model = _db.Machines.Include(machine => machine.Engineer).ToList(); 
  ViewBag.PageTitle = "View All Machines";
  return View(model);
}

    public ActionResult Create()
{
  ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
  return View();
}

    [HttpPost]
    public ActionResult Create(Machine machine)
    {
      if (machine.EngineerId == 0)
      {
        return RedirectToAction("Create");
      }
      _db.Machines.Add(machine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
       public ActionResult Details(int id)
    {
      Machine thisMachine = _db.Machines
                          .Include(machine => machine.Engineer)
                          .FirstOrDefault(machine => machine.MachineId == id);
      return View(thisMachine);
    }
     public ActionResult Edit(int id)
{
  Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
  ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
  return View(thisMachine);
}

   [HttpPost]
   public ActionResult Edit(Machine machine)
  {
    _db.Machines.Update(machine);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }
    public ActionResult Delete(int id)
 {
    Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
    return View(thisMachine);
 }

  [HttpPost, ActionName("Delete")]
  public ActionResult DeleteConfirmed(int id)
 {
    Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
    _db.Machines.Remove(thisMachine);
    _db.SaveChanges();
    return RedirectToAction("Index");
 }
  }
}