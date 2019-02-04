using MimeKit;
using YesterdayApi.Core.Email.Builder.Builders;
using YesterdayApi.Core.Email.Builder.Renderer;
using YesterdayApi.Core.Email.Builder.Types;

namespace YesterdayApi.Core.Email.Builder
{
    public class EmailDirector : IEmailDirector
    {
        private EmailBuilderBase _emailBuilder;
        private readonly IRazorViewToStringRenderer _razorViewToStringRenderer;

        public EmailDirector(IRazorViewToStringRenderer razorViewToStringRenderer)
        {
            _razorViewToStringRenderer = razorViewToStringRenderer;
        }

        public MimeMessage PrepareEmail(IEmailReceiver emailReceiver, Type type)
        {
            PrepareBuilder(type);
            _emailBuilder.ResetEmail();
            _emailBuilder.AppendUserDetails(emailReceiver);
            _emailBuilder.AddSubject();
            _emailBuilder.PrepareBody();
            var preparedEmail = _emailBuilder.Build();
            return preparedEmail;
        }

        private void PrepareBuilder(Type type)
        {
            if (type == Type.RegistrationConfirmation)
            {
                _emailBuilder = new RegistrationConfirmationEmailBuilder(_razorViewToStringRenderer);
            }
        }
    }
}