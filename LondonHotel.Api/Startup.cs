﻿using AutoMapper;
using LondonHotel.Api.DataAccess;
using LondonHotel.Api.Filters;
using LondonHotel.Api.Infrastructure;
using LondonHotel.Api.Models;
using LondonHotel.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LondonHotel.Api
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
         services.Configure<HotelInfo>(Configuration.GetSection("Info"));

         services.AddScoped<IRoomService, DefaultRoomService>();

         //use in-memory database for quick dev and test
         //TODO Swap with real database
         services.AddDbContext<HotelApiDbContext>(
            options => options.UseInMemoryDatabase("landondb"));

         services
            .AddMvc(options =>
            {
               options.Filters.Add<JsonExceptionFilter>();
               options.Filters.Add<RequireHttpsOrCloseAttribute>();
               options.Filters.Add<LinkRewritingFilter>();
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

         //for camel case 
         services.AddRouting(options => options.LowercaseUrls = true);

         //support for api versioning
         services.AddApiVersioning(options =>
         {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.ApiVersionReader = new MediaTypeApiVersionReader();
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
            options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);
         });

         //Need to add to Configure method below
         services.AddCors(options =>
         {
            options.AddPolicy("AllowMyApp",
               policy => policy.AllowAnyOrigin());
         });

         services.AddAutoMapper(options => options.AddProfile<MappingProfile>());
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

         //We have added RequireHttpsOrCloseAttribute to ensure that clients do not get https redirection and only
         //come through via https
         //app.UseHttpsRedirection();

         //Cors is configured in ConfigureServices method
         app.UseCors("AllowMyApp");

         app.UseMvc();
      }
   }
}
