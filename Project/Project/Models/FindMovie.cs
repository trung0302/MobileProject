using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{
    public class FindMovie
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        //public string FullImageUrl => AppSettings.ApiUrl + ImageUrl;
    }
}
