using Microsoft.AspNetCore.Mvc;

namespace HetBetereGroepje.HealthCheck.View.Controllers
{
    public class MainController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return Redirect("/home");
        }
    }
}
