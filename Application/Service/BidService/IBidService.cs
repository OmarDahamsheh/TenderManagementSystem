using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.Repository.BidRepo;
using Domain.Models;

namespace Application.Service.BidService
{
    public interface IBidService
    {
        public Task AddBid(BidDTO dto, int currentUserId);
        public Task<List<TenderListItemDTO>> GetOpenTenders();
        public Task AddFinancialProposal(FinancialProposalDTO dto);
        public Task AddTechnicalProposal(TechnicalProposalDTO dto);
    }
}
