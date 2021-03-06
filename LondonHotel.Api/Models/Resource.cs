﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LondonHotel.Api.Models
{
    public abstract class Resource : Link
   {
      [JsonIgnore]
      public Link Self { get; set; }
   }
}
