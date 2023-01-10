using HetBetereGroepje.HealthCheck.Domain;
using HetBetereGroepje.HealthCheck.ILogic;
using HetBetereGroepje.HealthCheck.View.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace HetBetereGroepje.HealthCheck.View.Controllers
{
    public class HomeController : AuthController
    {
        private readonly IHealthCheckService healthCheckService;
        private readonly ITemplateService templateService;
        private readonly IResponseService responseService;
        public HomeController(IHealthCheckService healthCheckService, ITemplateService templateService,IResponseService responseService)
        {
            this.healthCheckService = healthCheckService;
            this.templateService = templateService;
            this.responseService = responseService;
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

            //IEnumerable<IHealthCheck> healthChecks = healthCheckService.GetHealthChecksByTenant(TenantID);
            Dictionary<IHealthCheck, IEnumerable<IResponse>> map = new Dictionary<IHealthCheck, IEnumerable<IResponse>>();

            foreach (IHealthCheck healthCheck in healthCheckService.GetHealthChecksByTenant(TenantID))
                map.Add(healthCheck, responseService.GetAllResponses(healthCheck.ID));


            return View((new HomeViewModel(
                HttpContext.Request.Path + HttpContext.Request.QueryString,
                map), templateService.GetTemplates()));
        }
    }
}
