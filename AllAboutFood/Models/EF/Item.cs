using System;
using System.Collections.Generic;

namespace AllAboutFood.Models.EF
{
    public partial class Item
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public int NameId { get; set; }
        public int DescriptionId { get; set; }
        public bool IsVegan { get; set; }
        public bool HasPeanut { get; set; }
        public decimal Price { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}
