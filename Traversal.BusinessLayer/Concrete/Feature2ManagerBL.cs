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
    public class Feature2ManagerBL : IFeature2ServiceBL
    {
        private readonly IFeature2DAL _feature2Dal;

        public Feature2ManagerBL(IFeature2DAL feature2Dal)
        {
            _feature2Dal = feature2Dal;
        }

        public void TDelete(Feature2 t)
        {
            _feature2Dal.Delete(t);
        }

        public Feature2 TGetByID(int id)
        {
            return _feature2Dal.GetByID(id);
        }

        public List<Feature2> TGetList()
        {
            return _feature2Dal.GetList();
        }

        public void TInsert(Feature2 t)
        {
            _feature2Dal.Insert(t);
        }

        public void TUpdate(Feature2 t)
        {
            _feature2Dal.Update(t);
        }
    }
}
