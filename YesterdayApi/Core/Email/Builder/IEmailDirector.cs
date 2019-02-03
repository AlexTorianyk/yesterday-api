using MimeKit;
using YesterdayApi.Core.Email.Builder.Types;
using YesterdayApi.Utilities.AutomaticDI;

namespace YesterdayApi.Core.Email.Builder
{
    public interface IEmailDirector : IScoped
    {
        MimeMessage PrepareEmail(IEmailReceiver emailReceiver, Type type);
    }
}