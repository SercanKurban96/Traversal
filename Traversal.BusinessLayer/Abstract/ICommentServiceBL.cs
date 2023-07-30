using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traversal.EntityLayer.Concrete;

namespace Traversal.BusinessLayer.Abstract
{
    public interface ICommentServiceBL : IGenericServiceBL<Comment>
    {
        // Destination ID getirme
        List<Comment> TGetDestinationByID(int id);

        // Comment BlogID kısmını getirme
        List<Comment> TGetListCommentWithDestination();

        // Comment AppUser kullanıcıyı getirme
        List<Comment> TGetListCommentWithDestinationAndUser(int id);
    }
}
