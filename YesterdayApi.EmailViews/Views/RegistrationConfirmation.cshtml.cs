using Microsoft.AspNetCore.Mvc.RazorPages;

namespace YesterdayApi.EmailViews.Views
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