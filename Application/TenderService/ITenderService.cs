using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;


namespace Application.TenderService
{
    public interface ITenderService
    {
        public void CreateTender(TenderDetailsDto tenderDto, int CurrentUserId);
    }
}
