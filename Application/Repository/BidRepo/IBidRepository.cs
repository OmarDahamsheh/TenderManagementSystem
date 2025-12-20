using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure;

namespace Application.Repository.BidRepo
{
    public interface IBidRepository
    {
        public Task AddBid(Bid bid);
        public Task<List<Tender>> GetOpenTenders();
        public Task AddFinancialProposal(FinancialProposal proposal);
        public Task AddTechnicalProposal(TechnicalProposal proposal);

    }
}
