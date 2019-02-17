using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorHtmlEmails.RazorClassLib.Views
{
    public class RegistrationConfirmation : PageModel
    {
        public string UserName { get; set; }

        public RegistrationConfirmation(string userName)
        {
            UserName = userName;
        }

        public RegistrationConfirmation()
        {
        }
    }
}