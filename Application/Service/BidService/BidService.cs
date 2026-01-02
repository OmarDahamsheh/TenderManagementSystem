using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.Repository.BidRepo;
using Application.UnitOfWork;
using Domain.Models;

namespace Application.Service.BidService
{
    public class BidService : IBidService
    {
        private readonly IUnitOfWork _uow;
        public BidService(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }


        public async Task AddBid(BidDTO dto)
        {

            var bid = new Bid
            {
                Name = dto.Name,
                UserId = dto.UserId,
                TenderId = dto.TenderId
            };

           await _uow.BidsRepo.AddBid(bid);
           await _uow.Commit();
        }

        public async Task<List<TenderListItemDTO>> GetOpenTenders()
        {
            var tenders = await _uow.BidsRepo.GetOpenTenders();

            return tenders.Select(t => new TenderListItemDTO
            {
                Id = t.Id,
                Title = t.Title,
                Industry = t.Industry,
                TenderType = t.TenderType,
                Location = t.Location,
                StartDate = t.StartDate,
                EndDate = t.ClosingDate,
                Budget = t.Budget
            }).ToList();

        }

        public async Task AddFinancialProposal(FinancialProposalDTO dto)
        {
            var fproposal=new FinancialProposal
            {
                ItemName = dto.ItemName,
                Description = dto.Description,
                Quantity = dto.Quantity,
                UnitPrice = dto.UnitPrice,
                BidId = dto.BidId,
                TotalPrice = dto.Quantity * dto.UnitPrice
            };

            await _uow.BidsRepo.AddFinancialProposal(fproposal);
            await _uow.Commit();
        }

        public async Task AddTechnicalProposal(TechnicalProposalDTO dto)
        {
            var tproposal=new TechnicalProposal
            {
                TechnicalApproach = dto.TechnicalApproach,
                Methodology = dto.Methodology,
                ProposedSolution = dto.ProposedSolution,
                BidId = dto.BidId
            };

            await _uow.BidsRepo.AddTechnicalProposal(tproposal);
            await _uow.Commit();
        }
    }
}
