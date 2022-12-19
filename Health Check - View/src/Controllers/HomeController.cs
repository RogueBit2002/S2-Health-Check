using HetBetereGroepje.HealthCheck.Domain;
using HetBetereGroepje.HealthCheck.ILogic;
using HetBetereGroepje.HealthCheck.View.Models;
using Microsoft.AspNetCore.Mvc;

namespace HetBetereGroepje.HealthCheck.View.Controllers
{
    public class HomeController : AuthController
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

            //if (!IsLoggedIn)
            //return RedirectToLoginPage();

            /*
            HttpContext.GetOwinContext().Authentication.Challenge(
            new AuthenticationProperties { RedirectUri = "/" },
            OpenIdConnectAuthenticationDefaults.AuthenticationType);*/

            //HttpContext.GetOwinContext();

            IEnumerable<IHealthCheck> healthChecks = healthCheckService.GetHealthChecksByTenant(TenantID);


            return View((new HomeViewModel(
                HttpContext.Request.Path + HttpContext.Request.QueryString,
                healthChecks, 10), templateService.GetTemplates()));
        }
    }
}
