using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class TechnicalProposalDTO
    {
        public string TechnicalApproach { get; set; }
        public string Methodology { get; set; }
        public string ProposedSolution { get; set; }
        public int BidId { get; set; }
    }
}
