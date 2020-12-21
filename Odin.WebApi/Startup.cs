using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Odin.Common.Constants;
using Odin.DataAccess.Context;
using Odin.WebApi.Extensions;
using Odin.WebApi.Filters;
using System.Globalization;

namespace Odin.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddMvcCore(option =>
            {
                option.Filters.Add(new ExceptionHandlerFilter());
            });

            services.AddCors(options =>
            {
                options.AddPolicy(HeaderInformation.CorsPolicy, builder =>
                  builder.AllowAnyOrigin()
                         .AllowAnyMethod()
                         .AllowAnyHeader());
            });

            services.AddHealthChecks();

            services.AddControllers()
                    .AddFluentValidation(x => x.RunDefaultMvcValidationAfterFluentValidationExecutes = false)
                    .AddNewtonsoftJson(option =>
                    {
                        option.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                        option.SerializerSettings.Culture = new CultureInfo("tr-TR");
                        option.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
                    });

            services.AddDbContext<OdinDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("OdinDbContext")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Odin.WebApi", Version = "v1" });
            });

            services.InstallServices();
            services.ConfigureMapping();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Odin.WebApi v1"));
            }

            app.UseCors(HeaderInformation.CorsPolicy);

            app.UseCustomHealthCheck();

            app.UseHttpsRedirection();

            app.UseResponseCaching();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
