using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.DTO
{
    public class BidDTO
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public int TenderId { get; set; }
        public PaymentMethod PaymentMethods { get; set; }
    }
}
