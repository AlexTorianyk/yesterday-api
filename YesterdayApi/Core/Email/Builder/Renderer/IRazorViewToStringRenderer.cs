using System.Threading.Tasks;
using YesterdayApi.Utilities.AutomaticDI;

namespace YesterdayApi.Core.Email.Builder.Renderer
{
    public interface IRazorViewToStringRenderer : IScoped
    {
        Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model);
    }
}