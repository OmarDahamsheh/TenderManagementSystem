using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Repository.EvaluationRepo
{
    public interface IEvaluationRepository
    {
        public Task<List<Bid>> GetBidsSortedByPrice();
        public Task<int> AwardedToUserWithHighestBid(int tenderId);
    }
}
