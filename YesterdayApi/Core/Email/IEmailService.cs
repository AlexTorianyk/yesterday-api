using System.Threading.Tasks;
using YesterdayApi.Core.Email.Builder.Types;
using YesterdayApi.Utilities.AutomaticDI;

namespace YesterdayApi.Core.Email
{
    public interface IEmailService : IScoped
    {
        Task SendEmail(IEmailReceiver details, Type type);
    }
}