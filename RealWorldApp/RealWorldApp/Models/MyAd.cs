using System;
using System.Collections.Generic;
using System.Text;

namespace RealWorldApp.Models
{
    public class MyAd
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Model { get; set; }
        public string Location { get; set; }
        public string Company { get; set; }
        public DateTime DatePosted { get; set; }
        public bool IsFeatured { get; set; }
        public string ImageUrl { get; set; }
        public string IsFeaturedAd => IsFeatured ? "Featured" : "Free";
        public string AddPostedDate => DatePosted.ToString("y");
        public string FullImageUrl => $"https://cvehicles1.azurewebsites.net/{ImageUrl}";
    }
}
