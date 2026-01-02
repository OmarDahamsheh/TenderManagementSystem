using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.UnitOfWork;
using Domain.Models;

namespace Application.Service.TenderService
{
    public class TenderService : ITenderService
    {
        private readonly IUnitOfWork _uow;
        public TenderService(IUnitOfWork uow)
        {
            _uow = uow;
        }


        public async Task<int> CreateTender(CreateTenderDTO dto, int CurrentUserId)
        {
            var tender = new Tender
            {
                Title = dto.Title,
                Description = dto.Description,
                Budget = dto.Budget,
                StartDate = dto.StartDate,
                ClosingDate = dto.EndDate,
                CreatedByUserId = CurrentUserId,
                Industry = dto.Industry,
                TenderType = dto.TenderType,
                Location = dto.Location
            };

            await _uow.TendersRepo.CreateTender(tender);
            await _uow.Commit();
            return tender.Id;
        }

        public async Task AddEligibilityCriteria(EligibilityCriteriaDTO dto)
        {
            var criteria = new EligibilityCriteria
            {
                Criteria = dto.Criteria,
                TenderId = dto.TenderId
            };

            await _uow.TendersRepo.AddEligibilityCriteria(criteria);
            await _uow.Commit();

        }

        public async Task AddTenderDocument(TenderDocumentDTO dto)
        {
            var document = new TenderDocument
            {
                DocumentName = dto.DocumentName,
                //DocumentContent = dto.DocumentContent,
                TenderId = dto.TenderId,
            };
            await _uow.TendersRepo.AddTenderDocument(document);
            await _uow.Commit();
        }

        public async Task DeleteTender(int tenderId)
        {
            await _uow.TendersRepo.DeleteTender(tenderId);
            await _uow.Commit();
        }

        public async Task DeleteEligibilityCriteria(int criteriaId)
        {
            await _uow.TendersRepo.DeleteEligibilityCriteria(criteriaId);
            await _uow.Commit();
        }
        public async Task DeleteTenderDocument(int documentId)
        {
            await _uow.TendersRepo.DeleteTenderDocument(documentId);
            await _uow.Commit();
        }

        public async Task UpdateTender(CreateTenderDTO dto, int tenderId)
        {
            var tender = await _uow.TendersRepo.FindTenderById(tenderId);

            tender.Title = dto.Title;
            tender.Description = dto.Description;
            tender.Budget = dto.Budget;
            tender.StartDate = dto.StartDate;
            tender.ClosingDate = dto.EndDate;
            tender.Industry = dto.Industry;
            tender.TenderType = dto.TenderType;
            tender.Location = dto.Location;

            await _uow.Commit();
        }
        public async Task UpdateCriteria(EligibilityCriteriaDTO dto, int criteriaId)
        {
            var criteria = await _uow.TendersRepo.FindCriteriaById(criteriaId);

            criteria.Criteria = dto.Criteria;

            await _uow.Commit();
        }

        public async Task UpdateDocument(TenderDocumentDTO dto, int documentId)
        {
            var document = await _uow.TendersRepo.FindDocumentById(documentId);

            document.DocumentName = dto.DocumentName;

            await _uow.Commit();
        }
    }
}
