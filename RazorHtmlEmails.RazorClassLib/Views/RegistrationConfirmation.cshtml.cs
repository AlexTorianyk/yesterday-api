using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorHtmlEmails.RazorClassLib.Views
{
    public class RegistrationConfirmation : PageModel
    {
        private string UserName;

        public RegistrationConfirmation(string userName)
        {
            UserName = userName;
        }

        public RegistrationConfirmation()
        {
        }
    }
}