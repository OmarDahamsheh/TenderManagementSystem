using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UnitOfWork;
using Domain.Models;

namespace Application.Service.EvaluationService
{
    public class EvaluationService : IEvaluationService
    {
        private readonly IUnitOfWork _uow;
        public EvaluationService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<Bid>> GetBidsSortedByPrice()
        {
            return await _uow.EvaluationRepo.GetBidsSortedByPrice();
        }

        public async Task AwardedToUserWithHighestBid(int tenderId) {

            var tender=await _uow.TendersRepo.FindTenderById(tenderId);

            if (tender == null)throw new Exception("Tender not found");
            
            tender.AwardedToUserId = await _uow.EvaluationRepo.AwardedToUserWithHighestBid(tenderId);
            
            await _uow.Commit();

        }
    }
}
