using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Fundamentals
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.MapWhen(
                context => context.Request.Path.StartsWithSegments(new PathString("/routing-attributes")), // important to start from /
                application => { 
                    application.UseRouting(); 
                    application.UseEndpoints(endpoint => endpoint.MapControllers()); 
                }
            );

            app.MapWhen(
                context => context.Request.Path.StartsWithSegments(new PathString("/routing-endpoints")),
                application => {
                    application.UseRouting();
                    application.UseEndpoints(
                        endpoint => {
                            endpoint.MapControllerRoute(
                                "general route mapping",
                                "/routing-endpoints/{[controller]}/Test{[action]}" // not clear why /routing-endpoints/{[controller]}/{[action]} as well mapped
                            );
                            endpoint.MapControllerRoute(
                                "specific route mapping",
                                "/routing-endpoints/{controller=ControllerEndpointRouting}/{action=SpecificAction}/{id?}"
                            );
                            endpoint.MapPost(
                                "/routing-endpoints/post-sample",
                                async context => await context.Response.WriteAsync("post-sample delegate executed")
                            );
                            // ToDo: add sample of custom routing
                            // ToDo: add routing constraints
                        }
                    ) ;
                }
                // routing without endpoints
                //services.AddMvc(mvcOtions => { mvcOtions.EnableEndpointRouting = false; }); // disable endpoint routing
                //application.UseMvc(routes =>
                //{
                //    routes.MapRoute(
                //        name: "default",
                //        template: "{controller=Home}/{action=Index}/{id?}");
                //});
            );


            // **********************************************************************

            // below required for attribute routing + services.AddControllers();
            //app.UseRouting();
            //app.UseEndpoints(endpoint => endpoint.MapControllers());



            //app.UseExceptionHandler("/ErrorHandlerAction");

            //app.UseRouting();
            //app.UseExceptionHandler("/StatusCode");
            //app.UseStatusCodePagesWithReExecute("/StatusCode", "?code={0}");
            //app.Map("/StatusCode", ap => ap.Run(async context =>
            //{
            //    await context.Response.WriteAsync($"Err: {context.Request.Query["code"]}");
            //}));
            //app.UseEndpoints(endpoints =>
            //{
            //    //endpoints.MapControllers();

            //    endpoints.MapGet("/hello-world", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });

            //    endpoints.MapGet("/error400", async context =>
            //    {
            //        //throw new Exception();
            //        context.Response.StatusCode = 400;
            //        //context.Response.
            //        await context.Response.WriteAsync("Bad Request cccc");
            //    });
            //});

            //// separate pipeline for web api
            //app.MapWhen(c => c.Request.Path.StartsWithSegments(
            //    new PathString("/api")),
            //    appC =>
            //    {
            //        appC.UseRouting();
            //        appC.UseDeveloperExceptionPage();
            //        appC.UseEndpoints(endpoints => endpoints.MapControllers());
            //    }
            //);

            //app.MapWhen(c => c.Request.Path.StartsWithSegments(
            //    new PathString("razor")),
            //    appC =>
            //    {
            //        appC.UseRouting();
            //        appC.UseStatusCodePagesWithRedirects("/StatusCode?code={0}");
            //        appC.UseEndpoints(endpoints => endpoints.MapRazorPages());
            //    }
            //);

        }
    }
}
