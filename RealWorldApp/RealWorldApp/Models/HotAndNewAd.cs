using System;
using System.Collections.Generic;
using System.Text;

namespace RealWorldApp.Models
{
    public class HotAndNewAd
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Model { get; set; }
        public string Company { get; set; }
        public bool IsFeatured { get; set; }
        public string ImageUrl { get; set; }
        public string FullImageUrl => $"https://cvehicles1.azurewebsites.net/i{ImageUrl}";
        /*public string FullImageUrl => $"https://cvehicles1.azurewebsites.net/images/{ImageUrl}";*/
    }
}
