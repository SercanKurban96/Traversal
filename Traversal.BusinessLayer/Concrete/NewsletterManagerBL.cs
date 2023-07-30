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
    public class NewsletterManagerBL : INewsletterServiceBL
    {
        private readonly INewsletterDAL _newsletterDal;

        public NewsletterManagerBL(INewsletterDAL newsletterDal)
        {
            _newsletterDal = newsletterDal;
        }

        public void TDelete(Newsletter t)
        {
            _newsletterDal.Delete(t);
        }

        public Newsletter TGetByID(int id)
        {
            return _newsletterDal.GetByID(id);
        }

        public List<Newsletter> TGetList()
        {
            return _newsletterDal.GetList();
        }

        public void TInsert(Newsletter t)
        {
            _newsletterDal.Insert(t);
        }

        public void TUpdate(Newsletter t)
        {
            _newsletterDal.Update(t);
        }
    }
}
