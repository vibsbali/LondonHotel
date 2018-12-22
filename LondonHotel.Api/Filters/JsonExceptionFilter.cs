using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LondonHotel.Api.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LondonHotel.Api.Filters
{
   //Filter is a chunk of code that run before and after ASP.Net core processes a request
   public class JsonExceptionFilter : IExceptionFilter
   {
      private readonly IHostingEnvironment _environment;

      public JsonExceptionFilter(IHostingEnvironment environment)
      {
         _environment = environment;
      }

      public void OnException(ExceptionContext context)
      {
         ApiError error;

         if (_environment.IsDevelopment())
         {
            error = new ApiError
            {
               Message = context.Exception.Message,
               Detail = context.Exception.StackTrace
            };
         }
         else
         {
            error = new ApiError
            {
               Message = "A server error occured",
               Detail = ""
            };
         }

         context.Result = new ObjectResult(error)
         {
            StatusCode = 500
         };
      }
   }
}
