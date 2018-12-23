using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace LondonHotel.Api.Models
{
    public class Room : Resource
    {
        public string Name { get; set; }
        public decimal Rate { get; set; }
    }
}
