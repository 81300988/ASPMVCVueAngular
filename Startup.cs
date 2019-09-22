using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using vue_blog.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.AspNetCore.Identity;
namespace vue_blog
{
    public class Startup
    {
        private IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = _config["Connection"];
            services.AddDbContext<AppDbContext>(options=>
            {
                options.UseSqlServer(connection);
            });
            services.AddIdentity<IdentityUser, IdentityRole>(options =>{
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<AppDbContext>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions{
                    HotModuleReplacement = true
                });
            }
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapSpaFallbackRoute("spa-fallback", new{
                    controller = "Home", Action = "Index"
                });
                routes.MapRoute(
                    name: "default",
                    template: "{controller}=Home/{action}=Index/{id?}");
            });
        }
    }
}
