using HetBetereGroepje.HealthCheck.Domain.High;
using HetBetereGroepje.HealthCheck.ILogic;
using HetBetereGroepje.HealthCheck.View.Models;
using Microsoft.AspNetCore.Mvc;

namespace HetBetereGroepje.HealthCheck.View.Controllers
{
    public class QuestionController : Controller
    {
        private IQuestionService questionService;
        public QuestionController(IQuestionService questionService)
        {
            this.questionService = questionService;
        }
        [Route("/question/{id}")]
        public IActionResult Index(uint id)
        {
            QuestionViewModel model = new QuestionViewModel();
            IQuestion question = questionService.GetQuestion(id);
            model.id = question.ID;
            model.text = question.Text;
            return View(model);
        }
    }
}
