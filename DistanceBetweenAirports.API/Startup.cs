using DistanceBetweenAirports.Domain.Services;
using DistanceBetweenAirports.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using DistanceBetweenAirports.App.Behaviors;
using FluentValidation;
using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using DistanceBetweenAirports.API.Middleware;
using System;
using DistanceBetweenAirports.App.Queries;

namespace DistanceBetweenAirports.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddHttpClient<IAirportService, AirportService>();

            services.AddScoped<IDistanceCalculatorService, DistanceCalculatorService>();

            services.AddMediatR(typeof(DistanceBetweenAirports.App.Commands.CalculateDistanceCommand).GetTypeInfo().Assembly);
            services.AddValidatorsFromAssembly(typeof(DistanceBetweenAirports.App.Commands.CalculateDistanceCommandValidator).GetTypeInfo().Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));


            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Airport Distance API", Version = "v1" });
            });
        }
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Airport Distance API V1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
