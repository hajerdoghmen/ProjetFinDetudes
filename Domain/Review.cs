using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFE.Domain
{
    public class Review
    {
        public int ArticleId { get; set; }
        public int ReviewId { get; set; }
        public int Score { get; set; }
        public string Comments { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
