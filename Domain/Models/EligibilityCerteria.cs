using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class EligibilityCerteria
    {
        public int Id { get; set; }
        
        [Required]
        public string Criteria { get; set; }

        public int TenderId { get; set; }
        public Tender Tender { get; set; }

        public EligibilityCerteria() { }
        public EligibilityCerteria(string criteria, int tenderId)
        {
            Criteria = criteria;
            TenderId = tenderId;
        }
    }
}
