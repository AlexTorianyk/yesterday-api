using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace YesterdayApi.Utilities.Mapper
{
    public static class MapperExtension
    {
        public static void AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(configuration => { configuration.ValidateInlineMaps = false; });
        }
    }
}