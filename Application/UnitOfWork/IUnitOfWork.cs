using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repository.BidRepo;
using Application.Repository.EvaluationRepo;
using Application.Repository.TenderRepo;
using Application.Repository.UserRepo;

namespace Application.UnitOfWork
{
    public interface IUnitOfWork
    {
        ITenderRepository TendersRepo { get; }
        IBidRepository BidsRepo { get; }
        IEvaluationRepository EvaluationRepo { get; }
        IUserRepository UsersRepo { get; }
        Task Commit();
    }
}
