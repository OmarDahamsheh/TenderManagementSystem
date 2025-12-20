using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class TechnicalProposal
    {
        public int Id { get; set; }
        public string TechnicalApproach { get; set; }
        public string Methodology { get; set; }
        public string ProposedSolution { get; set; }
        public int BidId { get; set; }
        public Bid Bid { get; set; }

    }
}
