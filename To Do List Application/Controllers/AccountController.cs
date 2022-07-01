using domain_entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace To_Do_List_Application.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountDbContext dbAccounts;

        public AccountController(AccountDbContext dbAccounts)
        {
            this.dbAccounts = dbAccounts;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Account account)
        {
            var login = dbAccounts.Accounts.Where(x => x.Login == account.Login)
                .Where(x => x.Password == account.Password).ToList();
            if (login.Count != 0)
            {
                return RedirectToAction("Index", "ToDo");
            }
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Account account)
        {
            if (!string.IsNullOrWhiteSpace(account.Login)
                && !string.IsNullOrWhiteSpace(account.Password))
            {
                dbAccounts.Accounts.Add(account);
                dbAccounts.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(account);
        }
    }
}
