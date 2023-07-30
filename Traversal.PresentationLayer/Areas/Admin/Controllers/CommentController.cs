using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Abstract;
using Traversal.BusinessLayer.Concrete;
using Traversal.DataAccessLayer.EntityFramework;

namespace Traversal.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class CommentController : Controller
    {
        private readonly ICommentServiceBL _commentServiceBL;

        public CommentController(ICommentServiceBL commentServiceBL)
        {
            _commentServiceBL = commentServiceBL;
        }

        public IActionResult Index()
        {
            var values = _commentServiceBL.TGetListCommentWithDestination();
            return View(values);
        }

        public IActionResult DeleteComment(int id)
        {
            var values = _commentServiceBL.TGetByID(id);
            _commentServiceBL.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}
