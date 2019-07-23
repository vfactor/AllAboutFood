﻿using System;
using System.Collections.Generic;

namespace AllAboutFood.Models.EF
{
    public partial class Schedule
    {
        public int RestaurantId { get; set; }
        public int MondayStart { get; set; }
        public int MondayEnd { get; set; }
        public int TuesdayStart { get; set; }
        public int TuesdayEnd { get; set; }
        public int WednesdayStart { get; set; }
        public int WednesdayEnd { get; set; }
        public int ThursdayStart { get; set; }
        public int ThursdayEnd { get; set; }
        public int FridayStart { get; set; }
        public int FridayEnd { get; set; }
        public int SaturdayStart { get; set; }
        public int SaturdayEnd { get; set; }
        public int SundayStart { get; set; }
        public int SundayEnd { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}
