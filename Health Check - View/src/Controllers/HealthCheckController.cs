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
        private readonly IQuestionService questionService;
        private readonly IResponseService responseService;

        public HealthCheckController(IHealthCheckService healthCheckService, IQuestionService questionService, IResponseService responseService)
        {
            this.healthCheckService = healthCheckService;
            this.questionService = questionService;
            this.responseService = responseService;
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

            IEnumerable<IQuestion> questions = questionService.GetQuestionsByTemplate(healthCheck.TemplateID);

            HealthCheckViewModel model = new HealthCheckViewModel(healthCheck, questions);

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
            IHealthCheck healthCheck = healthCheckService.GetHealthCheck(hash);

            if (healthCheck == null)
                return NotFound();

            string email = collection.ContainsKey("email") ? collection["email"] : string.Empty;

            Dictionary<uint, int> answers = new Dictionary<uint, int>();
            foreach(var item in collection)
            {
                if (!uint.TryParse(item.Key, out uint answerId))
                    continue;

                if (!int.TryParse(item.Value, out int value))
                    continue;

                answers.Add(answerId, value);
            }

            responseService.CreateResponse(healthCheck.ID, email, answers);

            return View();
        }
    }
}
