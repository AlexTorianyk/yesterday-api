using MimeKit;
using YesterdayApi.Core.Email.Builder.Renderer;

namespace YesterdayApi.Core.Email.Builder.Builders
{
    public abstract class EmailBuilderBase
    {
        protected readonly IRazorViewToStringRenderer _razorViewToStringRenderer;

        protected EmailBuilderBase(
            IRazorViewToStringRenderer razorViewToStringRenderer)
        {
            _razorViewToStringRenderer = razorViewToStringRenderer;
        }

        public abstract void ResetEmail();
        public abstract void AppendUserDetails(IEmailReceiver details);
        public abstract void PrepareBody();
        public abstract void AddSubject();
        public abstract MimeMessage Build();
    }
}