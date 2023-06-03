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
  }
}