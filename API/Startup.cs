using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationService.Mapping;
using ApplicationService.Service;
using ApplicationService.Validation;
using AutoMapper;
using Entity;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using DataService.mapping;
using DataService;
using Microsoft.AspNetCore.SpaServices.AngularCli;

namespace API
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
            services.AddControllers();
            services.AddMvc()
        .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ValidateCountry>());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "AspProgHelp Api",
                    Description = " Example of Asp.NetCore webApi"
                });
            });
            services.AddSpaStaticFiles(Configuration =>
            {
                Configuration.RootPath = "angular8project/dist";
            });
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyMethod()
                   .AllowAnyOrigin()
                         .AllowAnyHeader());
                
            });
           

            services.AddAutoMapper(typeof(CountryMapper));
            services.AddScoped<ICountryServices, CountryService>();
            services.AddScoped<IStateServices, StateServices>();
            services.AddScoped<ICityServices, CityServices>();
            services.AddScoped<Country>();
            services.AddScoped<State>();
            services.AddScoped<City>();
            services.AddScoped<CountryEntityConfiguration>();
            services.AddScoped<StateEntityConfiguration>();
            services.AddScoped<CityEntityConfiguration>();
            services.AddDbContext<CountryDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "AspProgHelp Test API V1");
                    c.RoutePrefix = string.Empty;
                });
            }
            // app.UseSpaStaticFiles();
            app.UseStaticFiles();
           
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors("CorsPolicy");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=API}/{action=Index}/{id?}");
                
            });
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "angular8project";
                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
