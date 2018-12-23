using LondonHotel.Api.Filters;
using LondonHotel.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace LondonHotel.Api.Controllers
{
   [Route("/")]
   [ApiController]
   [ApiVersion("1.0")]
   public class RootController : ControllerBase
   {
      //Name is going to be used in Url.Link nameof(GetRoot)
      [HttpGet(Name = nameof(GetRoot))]
      [ProducesResponseType(200)]
      public IActionResult GetRoot()
      {
         var response = new RootResponse
         {
            Self =  Link.To(nameof(GetRoot)), //Url.Link(routeName: nameof(GetRoot), values: null),
            Rooms = Link.To(nameof(RoomsController.GetRooms)),
            Info = Link.To(nameof(InfoController.GetInfo))
         };

         return Ok(response);
      }
   }

   public class RootResponse : Resource
   {
      public Link Info { get; set; }

      public Link Rooms { get; set; }
   }
}
