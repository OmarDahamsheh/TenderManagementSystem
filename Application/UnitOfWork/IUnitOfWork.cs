using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.TenderRepo;

namespace Application.UnitOfWork
{
    public interface IUnitOfWork
    {
        ITenderRepository TendersRepo { get; }
        Task Commit();
    }
}
