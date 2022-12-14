using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HetBetereGroepje.HealthCheck.View.Controllers
{
    public class HomeController : Controller
    {
        [Route("/home")]
        public IActionResult Index()
        {
            ClaimsPrincipal cp = User;


            string id = cp.Claims.Where(c => c.Type == "utid").First().Value;
            return View();
        }
    }
}
