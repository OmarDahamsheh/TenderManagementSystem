using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class TenderDocumentDTO
    {
        public string DocumentName { get; set; }
        //public byte[] DocumentContent { get; set; }
        public int TenderId { get; set; }
    }
}
