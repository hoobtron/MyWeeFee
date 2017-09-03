using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MyWeeFee.Models;

namespace MyWeeFee
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
            // Add framework services.
            services.AddMvc();

            // register database context with Dependency Injection container 
            services.AddDbContext<MyWeeFeeContext>(options =>
                // read connectionstring of defined database from appsettings.json
                options.UseSqlite(Configuration.GetConnectionString("MyWeeFeeContextSQLite")));
                // alternatively, link directly:
                // options.UseSqlite("Data Source=MyWeeFee.db"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // seed DB with default datasets
            // try 1
            // app.ApplicationServices.GetRequiredService<MyWeeFeeContext>().EnsureSeeded();

            // try 2 - with scope
            /*
            var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using (var serviceScope = scopeFactory.CreateScope())
            {
                if (!serviceScope.ServiceProvider.GetService<MyWeeFeeContext>().AllMigrationsApplied())
                {
                    serviceScope.ServiceProvider.GetService<MyWeeFeeContext>().Database.Migrate();
                    serviceScope.ServiceProvider.GetService<MyWeeFeeContext>().EnsureSeeded();
                }
            }*/
            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
            });
        }
    }
}