using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traversal.BusinessLayer.Abstract.AbstractUoW;
using Traversal.DataAccessLayer.Abstract;
using Traversal.DataAccessLayer.UnitOfWork;
using Traversal.EntityLayer.Concrete;

namespace Traversal.BusinessLayer.Concrete.ConcreteUoW
{
    public class AccountManagerBL : IAccountServiceBL
    {
        private readonly IAccountDAL _accountDal;
        private readonly IUoWDAL _uowDal;

        public AccountManagerBL(IAccountDAL accountDal, IUoWDAL uowDal)
        {
            _accountDal = accountDal;
            _uowDal = uowDal;
        }

        public Account TGetByID(int id)
        {
            return _accountDal.GetByID(id);
        }

        public void TInsert(Account t)
        {
            _accountDal.Insert(t);
            _uowDal.Save();
        }

        public void TMultiUpdate(List<Account> t)
        {
            _accountDal.MultiUpdate(t);
            _uowDal.Save();
        }

        public void TUpdate(Account t)
        {
            _accountDal.Update(t);
            _uowDal.Save();
        }
    }
}
