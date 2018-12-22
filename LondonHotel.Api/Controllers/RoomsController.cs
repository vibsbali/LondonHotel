using System;
using Microsoft.AspNetCore.Mvc;

namespace LondonHotel.Api.Controllers
{
   [Route("/[Controller]")]
   [ApiController]
   public class RoomsController : ControllerBase
   {

      [HttpGet(Name = nameof(GetRooms))]
      [ProducesResponseType(200), ProducesResponseType(401), ProducesResponseType(400)]
      public IActionResult GetRooms()
      {
         throw new NotImplementedException();
      }
   }
}
