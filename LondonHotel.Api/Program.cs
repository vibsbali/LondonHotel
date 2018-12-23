using System;
using LondonHotel.Api.DataAccess;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LondonHotel.Api
{
   public class Program
   {
      public static void Main(string[] args)
      {
         var host = CreateWebHostBuilder(args).Build();
         InitializeDatabase(host);
         host.Run();
      }

      public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
          WebHost.CreateDefaultBuilder(args)
              .UseStartup<Startup>();

      //Database Seeding
      public static void InitializeDatabase(IWebHost host)
      {
         using (var scope = host.Services.CreateScope())
         {
            var services = scope.ServiceProvider;
            try
            {
               var task = SeedData.InitialiseAsync(services);
               task.Wait();
            }
            catch (Exception e)
            {
               var logger = services.GetRequiredService<ILogger<Program>>();
               logger.LogError(e, "An error occured seeding the database");
            }
         }
      }
   }
}
