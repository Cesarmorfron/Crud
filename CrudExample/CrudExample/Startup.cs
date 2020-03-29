using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudDomain.Contracts.Repositories;
using CrudDomain.Contracts.Services;
using CrudDomain.Services;
using CrudRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CrudExample
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICrudService, CrudService>();
            services.AddTransient<ICrudRepository, MockCrudRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "CRUD Example",
                    Version = "v1",
                    Description = "ASP.NET Core Web API"
                });
            });

            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            const string swagger = "/swagger/v1/swagger.json";

            app.UseSwagger().UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(swagger, "Feature Api");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
