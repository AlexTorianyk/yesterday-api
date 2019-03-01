using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MimeKit;
using YesterdayApi.Core.Email.Builder.Renderer;
using YesterdayApi.EmailViews.Views;

namespace YesterdayApi.Core.Email.Builder.Builders
{
    public class RegistrationConfirmationEmailBuilder : EmailBuilderBase
    {
        private PageModel _emailTemplate;
        private MimeMessage _email;
        private IEmailReceiver _emailReceiver;

        public RegistrationConfirmationEmailBuilder(
            IRazorViewToStringRenderer razorViewToStringRenderer) : base(razorViewToStringRenderer)
        {
        }

        public override void ResetEmail()
        {
            _email = new MimeMessage();
        }

        public override void AppendUserDetails(IEmailReceiver details)
        {
            _emailReceiver = details;
            _email.To.Add(new MailboxAddress(_emailReceiver.Email));
        }

        public override void AddSubject()
        {
            _email.Subject = "Confirm your registration on Yesterday";
        }

        public override async Task PrepareBody()
        {
            _emailTemplate = new RegistrationConfirmation(_emailReceiver.UserName);
            _email.Body =
                new TextPart(await _razorViewToStringRenderer.RenderViewToStringAsync(
                    "/Views/RegistrationConfirmation.cshtml",
                    _emailTemplate).ConfigureAwait(false));
        }

        public override MimeMessage Build()
        {
            _email.From.Add(new MailboxAddress("yesterday@yesterday.com"));
            return _email;
        }
    }
}