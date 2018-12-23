using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LondonHotel.Api.DataAccess;
using LondonHotel.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace LondonHotel.Api.Services
{
   public interface IRoomService
   {
      Task<Room> GetRoomsAsync(Guid roomId);
   }

   public class DefaultRoomService : IRoomService
   {
      private readonly HotelApiDbContext _context;
      private readonly IMapper _mapper;

      public DefaultRoomService(HotelApiDbContext context,IMapper mapper)
      {
         _context = context;
         _mapper = mapper;
      }

      public async Task<Room> GetRoomsAsync(Guid roomId)
      {
         var entity = await _context.Roooms.SingleOrDefaultAsync(r => r.Id == roomId);

         if (entity == null)
         {
            return null;
         }
         
         return _mapper.Map<Room>(entity);
      }
   }
}
