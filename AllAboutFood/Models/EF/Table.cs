using System;
using System.Collections.Generic;

namespace AllAboutFood.Models.EF
{
    public partial class Table
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public int NumberOfSeat { get; set; }
        public bool Actif { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}
