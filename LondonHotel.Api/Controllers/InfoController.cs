using System;
using LondonHotel.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace LondonHotel.Api.Controllers
{
   [Route("/[Controller]")]
   [ApiController]
   public class InfoController : ControllerBase
   {
      private HotelInfo _hotelInfo;

      //IOptions<HotelInfo> comes from configure services
      public InfoController(IOptions<HotelInfo> hotelInfoWrapper)
      {
         _hotelInfo = hotelInfoWrapper.Value;
      }


      [HttpGet(Name = nameof(GetInfo))]
      [ProducesResponseType(200)]
      public ActionResult<HotelInfo> GetInfo()
      {
         _hotelInfo.Href = Url.Link(nameof(GetInfo), null);
         return _hotelInfo;
      }
   }
}
