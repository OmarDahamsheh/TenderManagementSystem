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
        public ICollection<EligibilityCerteria> EligibilityCriteria { get; set; }= new List<EligibilityCerteria>();

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime ClosingDate { get; set; }

        [Required]
        public int CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }

        public int? AwardedToUserId { get; set; }
        public User? AwardedToUser { get; set; }

        public Tender() { }
        public Tender(string Title, string Description, decimal Budget, List<EligibilityCerteria> EligibilityCriteria, DateTime StartDate, DateTime ClosingDate, int CreatedByUserId)
        {
            this.Title = Title;
            this.Description = Description;
            this.Budget = Budget;
            this.EligibilityCriteria = EligibilityCriteria;
            this.StartDate = StartDate;
            this.ClosingDate = ClosingDate;
            this.CreatedByUserId = CreatedByUserId;
        }

    }
}
