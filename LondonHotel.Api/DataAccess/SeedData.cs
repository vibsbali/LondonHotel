using System;
using System.Linq;
using System.Threading.Tasks;
using LondonHotel.Api.Models;
using Microsoft.Extensions.DependencyInjection;

namespace LondonHotel.Api.DataAccess
{
    public class SeedData
    {
        public static async Task InitialiseAsync(IServiceProvider services)
        {
            await AddTestData(services.GetRequiredService<HotelApiDbContext>());
        }

        private static async Task AddTestData(HotelApiDbContext context)
        {
            if (context.Roooms.Any())
            {
                //already has some data
                return;
            }

            context.Roooms.Add(new RoomEntity
            {
                Id = Guid.Parse("C7452001-9996-4509-9926-40DE8FDF413B"),
                Name = "Oxford Suite",
                Rate = 10119
            });

            context.Roooms.Add(new RoomEntity
            {
                Id = Guid.Parse("756DCB5D-3005-4493-B3E0-3CF6D561CBAA"),
                Name = "Driscoll Suite",
                Rate = 23959
            });

            await context.SaveChangesAsync();
        }
    }
}
