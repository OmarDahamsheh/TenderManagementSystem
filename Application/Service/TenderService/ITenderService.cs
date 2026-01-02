using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;


namespace Application.Service.TenderService
{
    public interface ITenderService
    {

        public Task<int> CreateTender(CreateTenderDTO tenderDto, int CurrentUserId);
        public Task AddEligibilityCriteria(EligibilityCriteriaDTO dto);
        public Task AddTenderDocument(TenderDocumentDTO dto);
        public Task DeleteTender(int tenderId);
        public Task DeleteEligibilityCriteria(int criteriaId);
        public Task DeleteTenderDocument(int documentId);
        public Task UpdateTender(CreateTenderDTO tenderDto, int tenderId);
        public Task UpdateCriteria(EligibilityCriteriaDTO criteriaDto, int criteriaId);
        public Task UpdateDocument(TenderDocumentDTO documentDto, int documentId);
    }
}
