using HetBetereGroepje.HealthCheck.ILogic;
using HetBetereGroepje.HealthCheck.View.Models;
using Microsoft.AspNetCore.Mvc;

namespace HetBetereGroepje.HealthCheck.View.Controllers
{
    public class LoginController : AuthController
    {
        private const string FailedAttemptKey = "failed-login-attempt";

        private readonly IManagerService userService;

        public LoginController(IManagerService userService) => this.userService = userService;

        [Route(AppConstants.Paths.Login)]
        public IActionResult Index(string redirect)
        {
            LoginViewModel model = new LoginViewModel(
                HttpContext.Session.Keys.Contains(FailedAttemptKey),
                redirect);

            HttpContext.Session.Remove(FailedAttemptKey);

            return View(model);
        }

        [Route("/logout")]
        public new IActionResult Logout()
        {
            base.Logout();

            return Redirect(AppConstants.Paths.Login);
        }


        [Route("/login/try")]
        public IActionResult Try(IFormCollection collection)
        {
            string email = collection["email"];
            string password = collection["password"];
            string redirect = collection["redirect"];

            if(!userService.TryLogin(email, password, out uint id))
            {
                HttpContext.Session.Set(FailedAttemptKey, new byte[] { });
                return RedirectToLoginPage(redirect);
            }

            ManagerID = id;

            HttpContext.Session.Remove(FailedAttemptKey);

            return Redirect(string.IsNullOrEmpty(redirect) ? AppConstants.Paths.Home : redirect);
        }
    }
}
