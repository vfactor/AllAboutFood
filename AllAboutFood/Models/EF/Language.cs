using System;
using System.Collections.Generic;

namespace AllAboutFood.Models.EF
{
    public partial class Language
    {
        public Language()
        {
            RestaurantLanguage = new HashSet<RestaurantLanguage>();
        }

        public short Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }

        public virtual ICollection<RestaurantLanguage> RestaurantLanguage { get; set; }
    }
}
