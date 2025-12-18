using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;

namespace Application.TenderRepo
{
    public class TenderRepository : ITenderRepository
    {
        private Context _context;

        public TenderRepository(Context context)
        {
            _context = context;
        }

        public void CreateTender(Domain.Models.Tender tender)
        {

            _context.Tenders.Add(tender);
            //_context.SaveChanges();

        }


        //public void AddEligibilityCriteria(Domain.Models.EligibilityCerteria criteria) {

        //}                     ************   Continiue form here ************
    }
}
