using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Bid
    {
        public int BidId { get; set; }
        public string Name { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public int TenderId { get; set; }
        public Tender Tender { get; set; }

        public ICollection<BidDocument> BidDocuments { get; set; } = new List<BidDocument>();
        public ICollection<FinancialProposal>FinancialProposal { get; set; } = new List<FinancialProposal>();
        public ICollection<TechnicalProposal>TechnicalProposal { get; set; } = new List<TechnicalProposal>();
        
        public PaymentMethod PaymentMethods { get; set; }

        
        public Bid() { }
        public Bid(string name)
        {
            Name = name;
            
        }
    }
}
