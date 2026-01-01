using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Service.EvaluationService
{
    public interface IEvaluationService
    {
        public Task<List<Bid>> GetBidsSortedByPrice();
        public Task AwardedToUserWithHighestBid(int tenderId);
    }
}
