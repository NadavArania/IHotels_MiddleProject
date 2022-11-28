using IHotels.Viewer.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHotels.Viewer.Models.HotelResources
{
    public class Room
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public RoomType RoomType { get; set; }
        public int Capacity { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public bool HavePorch { get; set; }
        public bool HaveSafe { get; set; }
        public bool Availability { get; set; }
    }
}
