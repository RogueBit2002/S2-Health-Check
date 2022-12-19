namespace HetBetereGroepje.HealthCheck.View.Models
{
    public class LoginViewModel
    {
        public string email;
        public string password;
        public string redirect;
        public bool failedAttempt;

        public LoginViewModel(bool failedAttempt, string redirect)
        {
            this.failedAttempt = failedAttempt;
            this.redirect = redirect;
        }
    }
}
