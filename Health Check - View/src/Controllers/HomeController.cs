using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HetBetereGroepje.HealthCheck.View.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHealthCheckService healthCheckService;
        private readonly ITemplateService templateService;
        public HomeController(IHealthCheckService healthCheckService, ITemplateService templateService)
        {
            this.healthCheckService = healthCheckService;
            this.templateService = templateService;
        }

        [Route(AppConstants.Paths.Home)]
        public IActionResult Index()
        {
            ManagerID = 1;
            //if (!IsLoggedIn)
                //return RedirectToLoginPage();


            IEnumerable<IHealthCheck> healthChecks = healthCheckService.GetHealthChecksByManager(ManagerID);


            return View((new HomeViewModel(
                HttpContext.Request.Path + HttpContext.Request.QueryString,
                healthChecks, 10), templateService.GetTemplates()));
        }
    }
}
