using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Abstract.AbstractUoW;
using Traversal.EntityLayer.Concrete;
using Traversal.PresentationLayer.Areas.Admin.Models;

namespace Traversal.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IAccountServiceBL _accountServiceBL;

        public AccountController(IAccountServiceBL accountServiceBL)
        {
            _accountServiceBL = accountServiceBL;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AccountViewModel model)
        {
            var valueSender = _accountServiceBL.TGetByID(model.SenderID);
            var valueReceiver = _accountServiceBL.TGetByID(model.ReceiverID);
            //senderid, receiverid, amount

            valueSender.Balance -= model.Amount;
            valueReceiver.Balance += model.Amount;

            List<Account> modifiedAccount = new List<Account>()
            {
                valueSender,
                valueReceiver
            };

            _accountServiceBL.TMultiUpdate(modifiedAccount);

            return View();
        }
    }
}
