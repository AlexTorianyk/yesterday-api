using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YesterdayApi.Infrastructure.Data;
using YesterdayApi.Utilities.AutomaticDI;
using YesterdayApi.Utilities.Exceptions;
using YesterdayApi.Utilities.Mapper;
using YesterdayApi.Utilities.Swagger;
using YesterdayApi.Web.Cors;

namespace YesterdayApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMapper();
            services.AddSwagger();
            services.AddDbContext(Configuration);
            services.AddCorsPolicy();

            services.ConfigureDependencies();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCustomSwagger();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseCorsPolicy();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}