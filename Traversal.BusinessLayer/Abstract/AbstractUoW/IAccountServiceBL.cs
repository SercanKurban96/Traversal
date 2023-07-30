using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traversal.EntityLayer.Concrete;

namespace Traversal.BusinessLayer.Abstract.AbstractUoW
{
    public interface IAccountServiceBL : IGenericUoWServiceBL<Account>
    {
    }
}
