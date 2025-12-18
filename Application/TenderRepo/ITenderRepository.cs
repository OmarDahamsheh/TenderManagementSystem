using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TenderRepo
{
    public interface ITenderRepository
    {
        public void CreateTender(Domain.Models.Tender tender);
        //public void AddEligibilityCriteria(Domain.Models.EligibilityCerteria criteria);  ************   Continiue form here ************
    }
}
