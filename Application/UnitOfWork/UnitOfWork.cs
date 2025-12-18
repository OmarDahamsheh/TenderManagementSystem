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

        public UnitOfWork(Context context)
        {
            _context = context;
            TendersRepo = new TenderRepository(_context);
        }

        public void Commit()
        {
           _context.SaveChanges();
        }
    }
}
