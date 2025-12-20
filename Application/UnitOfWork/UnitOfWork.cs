using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repository.BidRepo;
using Application.Repository.TenderRepo;
using Infrastructure;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private Context _context;
        public ITenderRepository TendersRepo { get; }
        public IBidRepository BidsRepo { get; }
        public UnitOfWork(Context context, ITenderRepository tenderRepo, IBidRepository bidsRepo)
        {
            _context = context;
            TendersRepo = tenderRepo;
            BidsRepo = bidsRepo;
        }

        public async Task Commit()
        {
           await _context.SaveChangesAsync();
        }
    }
}
