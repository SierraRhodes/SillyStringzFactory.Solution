using Microsoft.AspNetCore.Mvc;

namespace SillyStringzFactory.Controllers
{
    public class HomeController : Controller
    {

      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }
    }
}