using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Tender
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Title { get; set; }
        
        [Required, MaxLength(250)]
        public string Description { get; set; }

        [Required,Column(TypeName="decimal(18,4)")]
        public decimal Budget { get; set; }

        [Required]
        public ICollection<EligibilityCriteria> EligibilityCriteria { get; set; }= new List<EligibilityCriteria>();
        public ICollection<TenderDocument> TenderDocument { get; set; }= new List<TenderDocument>();

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime ClosingDate { get; set; }

        [Required]
        public int CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }

        public int? AwardedToUserId { get; set; }
        public User? AwardedToUser { get; set; }

        public string Industry { get; set; }
        public string TenderType { get; set; }
        public string Location { get; set; }


        public Tender() { }
        public Tender(string Title, string Description, decimal Budget, List<EligibilityCriteria> EligibilityCriteria, DateTime StartDate, DateTime ClosingDate, int CreatedByUserId, string industry, string tenderType, string location)
        {
            this.Title = Title;
            this.Description = Description;
            this.Budget = Budget;
            this.EligibilityCriteria = EligibilityCriteria;
            this.StartDate = StartDate;
            this.ClosingDate = ClosingDate;
            this.CreatedByUserId = CreatedByUserId; 
            Industry = industry;
            TenderType = tenderType;
            Location = location;
        }

    }
}
