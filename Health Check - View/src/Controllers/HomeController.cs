using HetBetereGroepje.HealthCheck.Domain;
using HetBetereGroepje.HealthCheck.ILogic;
using HetBetereGroepje.HealthCheck.View.Models;
using Microsoft.AspNetCore.Mvc;

namespace HetBetereGroepje.HealthCheck.View.Controllers
{
    public class HomeController : AuthController
    {
        private readonly IHealthCheckService healthCheckService;
        public HomeController(IHealthCheckService healthCheckService)
        {
            this.healthCheckService = healthCheckService;
        }

        [Route(AppConstants.Paths.Home)]
        public IActionResult Index()
        {
            if (!IsLoggedIn)
                return RedirectToLoginPage();


            IEnumerable<IHealthCheck> healthChecks = healthCheckService.GetHealthChecksByManager(ManagerID);


            return View(new HomeViewModel(
                HttpContext.Request.Path + HttpContext.Request.QueryString,
                healthChecks));
        }
    }
}
