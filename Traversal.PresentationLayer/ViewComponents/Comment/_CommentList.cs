using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Concrete;
using Traversal.DataAccessLayer.Concrete;
using Traversal.DataAccessLayer.EntityFramework;

namespace Traversal.PresentationLayer.ViewComponents.Comment
{
    public class _CommentList : ViewComponent
    {
        CommentManagerBL cm = new CommentManagerBL(new EfCommentDAL());
        Context c = new Context();
        public IViewComponentResult Invoke(int id)
        {
            ViewBag.commentCount = c.Comments.Where(x => x.DestinationID == id).Count();
            var values = cm.TGetListCommentWithDestinationAndUser(id);
            return View(values);
        }
    }
}
