﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{
    public class Movie
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public int SoVe { get; set; }
        public string Language { get; set; }
        public double Rating { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string PlayingDate { get; set; }
        public string PlayingTime { get; set; }
        public string ImageUrl { get; set; }
        public string FullImageUrl { get; set; }
    }
}
