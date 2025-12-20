using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repository.BidRepo;
using Application.Repository.TenderRepo;

namespace Application.UnitOfWork
{
    public interface IUnitOfWork
    {
        ITenderRepository TendersRepo { get; }
        IBidRepository BidsRepo { get; }
        Task Commit();
    }
}
