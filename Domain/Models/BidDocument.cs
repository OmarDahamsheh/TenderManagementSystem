using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class BidDocument
    {
        public int Id { get; set; }
        public string DocumentPath { get; set; }

        public int BidId { get; set; }
        public Bid Bid { get; set; }

        public BidDocument() { }
        public BidDocument(string documentPath, int bidId)
        {
            DocumentPath = documentPath;
        }
    }
}
