using HetBetereGroepje.HealthCheck.Domain;
using HetBetereGroepje.HealthCheck.ILogic;
using HetBetereGroepje.HealthCheck.View.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace HetBetereGroepje.HealthCheck.View.Controllers
{
    public class HealthCheckController : AuthController
    {
        private readonly IHealthCheckService healthCheckService;
        public HealthCheckController(IHealthCheckService service)
        {
            healthCheckService = service;
        }

        [Route("/health-check/test")]
        public IActionResult Test()
        {
            return View();
        }

        [Route("/health-check/{hash}")]
        public IActionResult Index(string hash)
        {
            if(string.IsNullOrEmpty(hash))
                return NotFound();

            if (hash.Length != 32)
                return NotFound();

            IHealthCheck healthCheck = healthCheckService.GetHealthCheck(hash);

            if (healthCheck == null)
                return NotFound();


            HealthCheckViewModel model = new HealthCheckViewModel(healthCheck);

            return View(model);
        }

        [Route("/health-check/create")]
        public IActionResult Create(IFormCollection collection)
        {
            if (IsLoggedIn)
                healthCheckService.CreateHealthCheck(ManagerID, collection["name"]);
            
            return Redirect(collection["redirect"]);
        }

        [Route("/health-check/{hash}/submit")]
        public IActionResult Submit(string hash, IFormCollection collection)
        {
            /*IHealthCheck healthCheck = healthCheckService.GetHealthCheck(hash);

            if (healthCheck == null)
                return NotFound();*/

            foreach(var item in collection)
            {
                Console.Write(item.Value);
            }

            return Redirect("/home");
        }
    }
}
