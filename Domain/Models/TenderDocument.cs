using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class TenderDocument
    {
        public int Id { get; set; }
        public string DocumentName { get; set; }
        //public byte[] DocumentContent { get; set; }
        public int TenderId { get; set; }
        public Tender Tender { get; set; }

        public TenderDocument() { }
        public TenderDocument(string documentName)
        {
            DocumentName = documentName;
            //DocumentContent = documentContent;
            //TenderId = tenderId;
        }
    }
}
