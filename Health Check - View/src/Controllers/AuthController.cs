using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace HetBetereGroepje.HealthCheck.View.Controllers
{
    public abstract class AuthController : Controller
    {
        public bool IsLoggedIn => User.Claims.Any(c => c.Type == "utid");

        public string TenantID
        {
            get
            {
                return User.Claims.Where(c => c.Type == "utid").FirstOrDefault()?.Value ?? "";
            }
        }
    }
}
