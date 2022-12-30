using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{
    public class FindMovie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullImageUrl { get; set; }
        //public string FullImageUrl => AppSettings.ApiUrl + ImageUrl;
    }
}
