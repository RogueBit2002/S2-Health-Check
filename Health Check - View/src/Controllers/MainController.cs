using HetBetereGroepje.HealthCheck.View.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HetBetereGroepje.HealthCheck.View.Controllers
{
    public class MainController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return Redirect("/home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
