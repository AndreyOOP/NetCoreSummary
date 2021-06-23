using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCoreSummary.Services;

namespace NetCoreSummary
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container => DI configuration
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IScopedService, ScopedService>(); // register service, it could be used via constructor injection
            services.AddScoped<DisposableServiceSample>();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // could be used for investigation of the current pipeline execution state. For time measure between pipeline steps etc
            app.Use(next => context =>
            {
                // some action
                return next(context);
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers(); // required to use controllers mapping
                endpoints.Map("test", async context => await context.Response.WriteAsync("Hello test") );
            });

        }
    }
}
