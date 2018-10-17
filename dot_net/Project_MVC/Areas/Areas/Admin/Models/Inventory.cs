using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShop.Areas.Admin.Models
{
    public class Inventory
    {
        public string Group { get; set; }

        public int Count { get; set; }

        public double Value { get; set; }

        public double MinPrice { get; set; }

        public double MaxPrice { get; set; }

        public double AvgPrice { get; set; }
    }
}