using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Repository.TenderRepo
{
    public interface ITenderRepository
    {
        public Task CreateTender(Tender tender);
        public Task DeleteTender(int tenderId);
        public Task AddEligibilityCriteria(EligibilityCriteria criteria);
        public Task DeleteEligibilityCriteria(int criteriaId);

        public Task AddTenderDocument(TenderDocument document);
        public Task DeleteTenderDocument(int documentId);
        public Task<Tender> FindTenderById(int tenderId);
        public Task<EligibilityCriteria> FindCriteriaById(int criteriaId);
        public Task<TenderDocument> FindDocumentById(int documentId);

    }
}
