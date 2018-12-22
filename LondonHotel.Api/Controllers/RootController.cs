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
         var response = new
         {
            href = Url.Link(routeName: nameof(GetRoot), values: null),
            rooms = new
            {
               href = Url.Link(nameof(RoomsController.GetRooms), null)
            }
         };

         return Ok(response);
      }
   }
}
