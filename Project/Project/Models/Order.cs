using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{
    public class Order
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public string PlayingDate { get; set; }
        public string PlayingTime { get; set; }
        public string ImageUrl { get; set; }
        public DateTime ReservationTime { get; set; }
    }
}
