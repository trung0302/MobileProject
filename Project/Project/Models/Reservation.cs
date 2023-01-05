using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{
    public class Reservation
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Phone { get; set; }
        public string PhuongThuc { get; set; }
        public string Theater { get; set; }
        public string MovieId { get; set; }
        public string UserId { get; set; }
    }
}
