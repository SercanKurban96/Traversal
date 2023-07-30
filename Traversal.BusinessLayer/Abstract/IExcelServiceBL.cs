using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traversal.BusinessLayer.Abstract
{
    public interface IExcelServiceBL
    {
        byte[] ExcelList<T>(List<T> t) where T : class;
    }
}
