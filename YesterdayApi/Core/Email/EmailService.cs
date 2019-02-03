using System.Threading.Tasks;
using MailKit.Net.Smtp;
using YesterdayApi.Core.Email.Builder;
using YesterdayApi.Core.Email.Builder.Types;

namespace YesterdayApi.Core.Email
{
    public class EmailService : IEmailService
    {
        private readonly IEmailDirector _emailDirector;

        public EmailService(IEmailDirector emailDirector)
        {
            _emailDirector = emailDirector;
        }

        public async void SendEmail(IUserCredentials credentials, Type type)
        {
            var email = _emailDirector.PrepareEmail(credentials, type);
            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect("hostname", 465, true);
                client.Authenticate("login", "password");
                await client.SendAsync(email).ConfigureAwait(false);
            }
        }
    }
}