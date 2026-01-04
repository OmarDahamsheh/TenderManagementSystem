using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository.BidRepo
{
    public class BidRepository : IBidRepository
    {
        private readonly Context _context;

        public BidRepository(Context context)
        {
            _context = context;
        }

        public async Task AddBid(Bid bid)
        {
           await _context.Bids.AddAsync(bid);
        }
        public async Task<List<Tender>> GetOpenTenders()
        {
            var res=await (from x in _context.Tenders where x.TenderType == "Open" select x).ToListAsync();

            return res;
        }
        public async Task AddFinancialProposal(FinancialProposal proposal)
        {
            _context.FinancialProposals.Add(proposal);
        }

        public async Task AddTechnicalProposal(TechnicalProposal proposal)
        {
            _context.TechnicalProposals.Add(proposal);
        }

        public async Task<List<TenderDocument>> GetTenderDocuments() {
            var res = await _context.TenderDocuments.ToListAsync();
            return res;
        }
    }
}
