using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.DTO
{
    public class GetDocumentsDTO
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Notes { get; set; }
    }
}
