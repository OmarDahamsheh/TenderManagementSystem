using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class BidEvaluationDTO
    {
            public int BidId { get; set; }
            public string BidName { get; set; }
            public int TenderId { get; set; }
            public int? UserId { get; set; }
            public decimal TotalPrice { get; set; }
            public string PaymentMethod { get; set; }
    }
}
