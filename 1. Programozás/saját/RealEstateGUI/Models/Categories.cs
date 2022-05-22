using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RealEstateGUI.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Realestates = new HashSet<Realestates>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Realestates> Realestates { get; set; }
    }
}
