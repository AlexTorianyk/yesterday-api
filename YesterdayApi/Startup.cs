using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YesterdayApi.Infrastructure.Data;
using YesterdayApi.Utilities.AutomaticDI;
using YesterdayApi.Utilities.Exceptions;
using YesterdayApi.Utilities.Mapper;
using YesterdayApi.Utilities.Policies;
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

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = Configuration.GetSection("ApplicationUrl").Value;
                    options.RequireHttpsMetadata = false;

                    options.ApiName = "yesterdayApi";
                });
            services.AddMapper();
            services.AddSwagger();
            services.AddDbContext(Configuration);
            services.AddAdminPolicy();
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