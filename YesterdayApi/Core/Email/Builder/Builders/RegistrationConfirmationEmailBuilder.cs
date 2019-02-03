using Microsoft.AspNetCore.Mvc.RazorPages;
using MimeKit;
using RazorHtmlEmails.RazorClassLib.Views;
using YesterdayApi.Core.Email.Builder.Renderer;

namespace YesterdayApi.Core.Email.Builder.Builders
{
    public class RegistrationConfirmationEmailBuilder : EmailBuilder
    {
        private readonly IRazorViewToStringRenderer _razorViewToStringRenderer;
        private readonly string _subject;
        private PageModel _emailTemplate;
        private MimeMessage _email;
        private IUserCredentials _userCredentials;

        public RegistrationConfirmationEmailBuilder(
            IRazorViewToStringRenderer razorViewToStringRenderer) : base(razorViewToStringRenderer)
        {
            _emailTemplate = new RegistrationConfirmation();
            _razorViewToStringRenderer = razorViewToStringRenderer;
            _subject = "Confirm your registration on Yesterday";
        }

        public override void ResetEmail()
        {
            _email = new MimeMessage();
        }

        public override void AppendUserDetails(IUserCredentials credentials)
        {
            _userCredentials = credentials;
            _email.To.Add(new MailboxAddress(_userCredentials.Email));
        }

        public override async void PrepareBody()
        {
            _emailTemplate = new RegistrationConfirmation(_userCredentials.UserName);
            _email.Body =
                new TextPart(await _razorViewToStringRenderer.RenderViewToStringAsync(
                    "/Views/RegistrationConfirmation.cshtml",
                    _emailTemplate).ConfigureAwait(false));
        }

        public override MimeMessage BuildEmail()
        {
            _email.From.Add(new MailboxAddress("yesterday@yesterday.com"));
            return _email;
        }
    }
}