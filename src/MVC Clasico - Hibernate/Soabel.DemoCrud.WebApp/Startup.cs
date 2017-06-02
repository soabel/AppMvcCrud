using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Soabel.DemoCrud.Persistence.EntityFramework;
using Soabel.DemoCrud.Persistence;
using Soabel.DemoCrud.Domain.Base;
using Soabel.DemoCrud.Application.Service;
using Soabel.DemoCrud.Application.Contract;
using System.Data.Entity;

using AutoMapper;
using Soabel.DemoCrud.WebApp.Adapters;
using Soabel.DemoCrud.Persistence.NHibernate;

namespace Soabel.DemoCrud.WebApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            var cadenaConexion = Configuration.GetConnectionString("DemoDatabaseConnection");

            //Contexto Entity Framework
            //services.AddScoped<DbContext, DemoDatabaseContext>(x => new DemoDatabaseContext(cadenaConexion));
            //services.AddTransient<IUnitOfWork, UnitOfWork>();
            //services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            //services.AddTransient<IPersonaService, PersonaService>();

            //Contexto NHibernate
            NHibernateHelperExtend.Initialize(cadenaConexion);
            services.AddScoped<IUnitOfWork, NUnitOfWork>();
            services.AddTransient(typeof(IRepository<>), typeof(NRepository<>));
            services.AddTransient<IPersonaService, PersonaService>();

            //Automapper
            Mapper.Initialize(x=> x.AddProfile<MappingProfile>());
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
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
