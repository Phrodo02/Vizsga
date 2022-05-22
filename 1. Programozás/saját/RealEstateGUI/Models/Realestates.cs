using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RealEstateGUI.Models
{
    public partial class Realestates
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public long SellerId { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public bool Freeofcharge { get; set; }
        public string ImageUrl { get; set; }
        public int? Area { get; set; }
        public int? Rooms { get; set; }
        public int? Floors { get; set; }
        public string Latlong { get; set; }

        public virtual Categories Category { get; set; }
        public virtual Sellers Seller { get; set; }
    }
}
