using System;
using System.Threading.Tasks;
using AutoMapper;
using LondonHotel.Api.DataAccess;
using LondonHotel.Api.Models;
using LondonHotel.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LondonHotel.Api.Controllers
{
   [Route("/[Controller]")]
   [ApiController]
   public class RoomsController : ControllerBase
   {
      private readonly IRoomService _roomService;

      public RoomsController(IRoomService roomService)
      {
         _roomService = roomService;
      }

      [HttpGet(Name = nameof(GetRooms))]
      [ProducesResponseType(200), ProducesResponseType(401), ProducesResponseType(400)]
      public async Task<ActionResult<Room>> GetRooms()
      {
         throw new NotImplementedException();
      }

      // GET/rooms/{roomId}
      [HttpGet("{roomId}", Name = nameof(GetRoomById))]
      [ProducesResponseType(200), ProducesResponseType(400)]
      public async Task<ActionResult<Room>> GetRoomById(Guid roomId)
      {
         var room = await _roomService.GetRoomsAsync(roomId);
         if (room == null)
         {
            return NotFound();
         }

         return room;
      }
   }
}
