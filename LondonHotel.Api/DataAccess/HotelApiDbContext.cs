using LondonHotel.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace LondonHotel.Api.DataAccess
{
    public class HotelApiDbContext : DbContext
    {
        public HotelApiDbContext(DbContextOptions options)
            :base(options)
        {
            
        }

        public DbSet<RoomEntity> Roooms { get; set; }
    }
}
