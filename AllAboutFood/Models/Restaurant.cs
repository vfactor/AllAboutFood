using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutFood.Models.EF
{
    public partial class Restaurant
    {
        public class RestaurantLookup
        {
            public readonly int Id;
            public readonly string Text;

            public RestaurantLookup(int id, string text)
            {
                Id = id;
                Text = text;
            }
        }

        public RestaurantLookup MyLookupValue()
        {
            return new RestaurantLookup(Id, string.Concat(Name," ",Address," ",City," ",State," ",Zip));
        }
    }
}
