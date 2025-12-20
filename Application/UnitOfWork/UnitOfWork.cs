using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.TenderRepo;
using Infrastructure;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private Context _context;
        public ITenderRepository TendersRepo { get; }

        public UnitOfWork(Context context,ITenderRepository tenderRepo)
        {
            _context = context;
            TendersRepo = tenderRepo;
        }

        public async Task Commit()
        {
           await _context.SaveChangesAsync();
        }
    }
}
