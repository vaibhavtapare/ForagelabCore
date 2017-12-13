using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Foragelab.Core.DataModel;
using Foragelab.Core.DataModel.Repository;
using Microsoft.EntityFrameworkCore;
using Foragelab.Core.Services.Interfaces;
using Foragelab.Core.Services.Services;

namespace Foragelab.UI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddApplicationInsightsSettings(developerMode: env.IsDevelopment(), instrumentationKey: Environment.GetEnvironmentVariable("ApplicationInsightsInstrumentationKey"))
               .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationInsightsTelemetry();

            var connection = @"Server = PEEYUSH_AGRAWAL; UID = sa; password = clarion; Initial Catalog = CVAS; MultipleActiveResultSets = true;";
            services.AddDbContext<CVASContext>(options => options.UseSqlServer(connection));
            services.AddCors();
            services.AddMvc();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IFeedCodeServices, FeedCodeServices>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
