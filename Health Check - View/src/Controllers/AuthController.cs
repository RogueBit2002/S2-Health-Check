using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace HetBetereGroepje.HealthCheck.View.Controllers
{
    public abstract class AuthController : Controller
    {
        private const string ManagerIDKey = "manager-id";
        public bool IsLoggedIn => HttpContext.Session.Keys.Contains(ManagerIDKey);

        public uint ManagerID
        {
            get
            {
                return HttpContext.Session.GetUInt32(ManagerIDKey);
            }

            protected set
            {
                HttpContext.Session.SetUInt32(ManagerIDKey, value);
            }

        }

        public IActionResult RedirectToLoginPage(bool redirectToCurrent = true)
        {
            string r = HttpUtility.UrlEncode($"{HttpContext.Request.Path}{HttpContext.Request.QueryString}");
            string path = $"{AppConstants.Paths.Login}{(redirectToCurrent ? $"?redirect={r}" : "")}";

            return Redirect(path);
        }

        public IActionResult RedirectToLoginPage(string redirectPath)
        {
            string query = string.IsNullOrEmpty(redirectPath) ? "" : $"?redirect={HttpUtility.UrlEncode(redirectPath)}";
            return Redirect($"{AppConstants.Paths.Login}{query}");
        }

        public void Logout() => HttpContext.Session.Remove(ManagerIDKey);
    }
}
