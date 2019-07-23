using System;
using System.Collections.Generic;

namespace AllAboutFood.Models.EF
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            Item = new HashSet<Item>();
            RestaurantLanguage = new HashSet<RestaurantLanguage>();
            Table = new HashSet<Table>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public decimal Lat { get; set; }
        public decimal Long { get; set; }

        public virtual Schedule Schedule { get; set; }
        public virtual ICollection<Item> Item { get; set; }
        public virtual ICollection<RestaurantLanguage> RestaurantLanguage { get; set; }
        public virtual ICollection<Table> Table { get; set; }
    }
}
