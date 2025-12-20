using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure;

namespace Application.Repository.TenderRepo
{
    public class TenderRepository : ITenderRepository
    {
        private Context _context;

        public TenderRepository(Context context)
        {
            _context = context;
        }


        public async Task CreateTender(Tender tender)
        {

            await _context.Tenders.AddAsync(tender);
            //_context.SaveChanges();

        }


        public async Task AddEligibilityCriteria(EligibilityCriteria criteria)
        {
            await _context.EligibilityCriterias.AddAsync(criteria);
        }


        public async Task AddTenderDocument(TenderDocument document)
        {
            await _context.TenderDocuments.AddAsync(document);
        }

        public async Task DeleteTender(int tenderId)
        {
            var tender = await _context.Tenders.FindAsync(tenderId);
            if (tender != null)
            {
                _context.Tenders.Remove(tender);
            }
            else throw new Exception("Tender not found");

            //var tender = (from t in _context.Tenders
            //              where t.Id == tenderId
            //              select t).FirstOrDefault();

            //if (tender != null)
            //{
            //    _context.Tenders.Remove(tender);
            //}
        }

        public async Task DeleteEligibilityCriteria(int criteriaId)
        {
            var criteria = await _context.EligibilityCriterias.FindAsync(criteriaId);
            if (criteria != null)
            {
                _context.EligibilityCriterias.Remove(criteria);
            }
            else throw new Exception("Criteria not found");
        }

        public async Task DeleteTenderDocument(int documentId)
        {
            var document = await _context.TenderDocuments.FindAsync(documentId);
            if (document != null)
            {
                _context.TenderDocuments.Remove(document);
            }
            else throw new Exception("Document not found");
        }


        public async Task<Tender> FindTenderById(int tenderId)
        {
            var tender = await _context.Tenders.FindAsync(tenderId);

            if (tender == null)
                throw new Exception("Tender not found");

            return tender;
        }
        public async Task<EligibilityCriteria> FindCriteriaById(int criteriaId)
        {
            var criteria = await _context.EligibilityCriterias.FindAsync(criteriaId);

            if (criteria == null)
                throw new Exception("Criteria not found");

            return criteria;
        }
        public async Task<TenderDocument> FindDocumentById(int documentId)
        {

            var document = await _context.TenderDocuments.FindAsync(documentId);

            if (document == null)
                throw new Exception("Document not found");

            return document;
        }


    }
}