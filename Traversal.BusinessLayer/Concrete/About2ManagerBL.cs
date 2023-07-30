using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traversal.BusinessLayer.Abstract;
using Traversal.DataAccessLayer.Abstract;
using Traversal.EntityLayer.Concrete;

namespace Traversal.BusinessLayer.Concrete
{
    public class About2ManagerBL : IAbout2ServiceBL
    {
        private readonly IAbout2DAL _about2Dal;

        public About2ManagerBL(IAbout2DAL about2Dal)
        {
            _about2Dal = about2Dal;
        }

        public void TDelete(About2 t)
        {
            _about2Dal.Delete(t);
        }

        public About2 TGetByID(int id)
        {
            return _about2Dal.GetByID(id);
        }

        public List<About2> TGetList()
        {
            return _about2Dal.GetList();
        }

        public void TInsert(About2 t)
        {
            _about2Dal.Insert(t);
        }

        public void TUpdate(About2 t)
        {
            _about2Dal.Update(t);
        }
    }
}
