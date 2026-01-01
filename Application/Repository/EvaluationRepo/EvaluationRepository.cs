using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository.EvaluationRepo
{
    public class EvaluationRepository : IEvaluationRepository
    {
        private readonly Context _context;

        public EvaluationRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<Bid>> GetBidsSortedByPrice()
        {
            return await _context.Bids
            .OrderBy(b => b.FinancialProposal.Sum(fp => fp.Quantity * fp.UnitPrice))
            .ToListAsync();
        }

        public async Task<int> AwardedToUserWithHighestBid(int tenderId) 
        {
            
            var bid=await _context.Bids
                   .Where(b=>b.TenderId==tenderId)
                   .OrderByDescending(b => b.FinancialProposal
                   .Sum(fp => fp.Quantity * fp.UnitPrice))
                   .FirstOrDefaultAsync();

            var userId = bid?.UserId;
            
            if (userId == null) { 
                throw new Exception("No bids found to award.");
            }
            return (int)userId;
        }
    }
}
