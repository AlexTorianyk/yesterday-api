using YesterdayApi.Core.Email.Builder.Types;
using YesterdayApi.Utilities.AutomaticDI;

namespace YesterdayApi.Core.Email
{
    public interface IEmailService : IScoped
    {
        void SendEmail(IEmailReceiver details, Type type);
    }
}