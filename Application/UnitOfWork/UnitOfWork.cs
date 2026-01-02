using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repository.BidRepo;
using Application.Repository.EvaluationRepo;
using Application.Repository.TenderRepo;
using Application.Repository.UserRepo;
using Infrastructure;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private Context _context;
        public ITenderRepository TendersRepo { get; }
        public IBidRepository BidsRepo { get; }

        public IEvaluationRepository EvaluationRepo { get; }
        public IUserRepository UsersRepo { get; }

        public UnitOfWork(Context context, ITenderRepository tenderRepo,
            IBidRepository bidsRepo, IEvaluationRepository evaluationRepository,IUserRepository userRepository)
        {
            _context = context;
            TendersRepo = tenderRepo;
            BidsRepo = bidsRepo;
            EvaluationRepo = evaluationRepository;
            UsersRepo = userRepository;
        }

        public async Task Commit()
        {
           await _context.SaveChangesAsync();
        }
    }
}
