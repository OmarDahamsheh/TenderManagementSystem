using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
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

        public async Task<List<BidEvaluationDTO>> GetBidsSortedByPrice()
        {
            var bids = await _uow.EvaluationRepo.GetBidsSortedByPrice();

            return bids.Select(b => new BidEvaluationDTO
            {
                BidId = b.BidId,
                BidName = b.Name,
                TenderId = b.TenderId,
                UserId = b.UserId,
                TotalPrice = b.FinancialProposal.Sum(fp => fp.TotalPrice),
                PaymentMethod = b.PaymentMethods.ToString()
            }).ToList();
        }

        public async Task AwardedToUserWithHighestBid(int tenderId) {

            var tender=await _uow.TendersRepo.FindTenderById(tenderId);

            if (tender == null)throw new Exception("Tender not found");
            
            tender.AwardedToUserId = await _uow.EvaluationRepo.AwardedToUserWithHighestBid(tenderId);
            
            await _uow.Commit();

        }
    }
}
