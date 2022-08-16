using Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Persistence;
using System;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private const string DefaultCorsPolicyName = "localhost";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddApplicationServices();
            services.AddPersistence(Configuration);

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments(string.Format(@"{0}\DYNACORE.xml", AppDomain.CurrentDomain.BaseDirectory));
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "DYNACORE",
                });
            });
            #endregion


            #region API Versioning
            // Add API Versioning to the Project
            services.AddApiVersioning(config =>
            {
                // Specify the default API Version as 1.0
                config.DefaultApiVersion = new ApiVersion(1, 0);
                // If the client hasn't specified the API version in the request, use the default API version number 
                config.AssumeDefaultVersionWhenUnspecified = true;
                // Advertise the API versions supported for the particular endpoint
                config.ReportApiVersions = true;
            });
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBMAY9C3t2VVhiQlFaclxJVHxIekx0RWFbb1h6cVRMYV9BNQtUQF1hS35bd0BjX3pbc31XQmJe");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }



            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //app.UseCors(DefaultCorsPolicyName);

            #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DYNACORE");
            });
            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");

                //endpoints.MapAreaControllerRoute(
                //    name: "api",
                //    areaName: "areas",
                //    pattern: "{api}/{controller}/{action}/",
                //    new { id = RouteParameter.Optional, action = RouteParameter.Optional });


            });
        }
    }
}
