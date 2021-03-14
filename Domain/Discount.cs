using System;
using System.Collections.Generic;
using System.Text;

namespace PFE.Domain
{
    public class Discount
    {
        public int DiscoutId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Percent { get; set; }

    }
}