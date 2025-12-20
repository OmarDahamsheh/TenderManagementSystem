using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class EligibilityCriteria
    {
        public int Id { get; set; }

        public string Criteria { get; set; }

        public int TenderId { get; set; }
        public Tender Tender { get; set; }

        public EligibilityCriteria() { }
        public EligibilityCriteria(string criteria)
        {
            Criteria = criteria;
            //TenderId = tenderId;
        }
    }
}
