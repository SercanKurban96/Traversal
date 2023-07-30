using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traversal.DataAccessLayer.Concrete;

namespace Traversal.DataAccessLayer.UnitOfWork
{
    public class UoWDAL : IUoWDAL
    {
        private readonly Context _context;

        public UoWDAL(Context context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
