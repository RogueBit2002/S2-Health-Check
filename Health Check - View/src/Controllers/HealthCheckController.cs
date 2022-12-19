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
        private readonly ITemplateService templateService;

        public HealthCheckController(IHealthCheckService healthCheckService, IQuestionService questionService, IResponseService responseService, ITemplateService templateService)
        {
            this.healthCheckService = healthCheckService;
            this.questionService = questionService;
            this.responseService = responseService;
            this.templateService = templateService;
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

        [Route("/health-check/create")]
        public IActionResult Create(IFormCollection formCollection)
        {
            /*if (!IsLoggedIn)
                return RedirectToLoginPage();*/

            string name = formCollection["name"];
            uint templateId = uint.Parse(formCollection["template"]);

            healthCheckService.CreateHealthCheck(TenantID, templateId, name);
            return Redirect("/home");
        }


        [Route("/health-check/{hash}/result")]
        public IActionResult Result(string hash)
        {
            /*if (!IsLoggedIn)
                return RedirectToLoginPage();*/

            IHealthCheck healthCheck = healthCheckService.GetHealthCheck(hash);

            if (healthCheck == null)
                return NotFound();

            IEnumerable<IResponse> responses = responseService.GetAllResponses(healthCheck.ID);
            IEnumerable<IQuestion> questions = questionService.GetQuestionsByTemplate(healthCheck.TemplateID);

            return View("Result", (healthCheck, responses, questions));
        }
    }
}
