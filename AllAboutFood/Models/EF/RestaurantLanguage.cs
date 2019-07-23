using System;
using System.Collections.Generic;

namespace AllAboutFood.Models.EF
{
    public partial class RestaurantLanguage
    {
        public int RestaurantId { get; set; }
        public short LanguageId { get; set; }

        public virtual Language Language { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
