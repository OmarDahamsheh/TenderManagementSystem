using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.UnitOfWork;
using Domain.Models;

namespace Application.TenderService
{
    public class TenderService : ITenderService
    {
        private readonly IUnitOfWork _uow;
        public TenderService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void CreateTender(TenderDetailsDto dto, int CurrentUserId)
        {
            var tender = new Tender
            {
                Title = dto.Title,
                Description = dto.Description,
                Budget = dto.Budget,
                StartDate = dto.StartDate,
                ClosingDate = dto.EndDate,
                CreatedByUserId = CurrentUserId
            };

            _uow.TendersRepo.CreateTender(tender);
            _uow.Commit();
        }

   
    }
}
