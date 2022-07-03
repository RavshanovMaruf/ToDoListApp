using domain_entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace To_Do_List_Application.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountDbContext dbAccounts;

        /// <summary>
        /// Gets AccountDbContext
        /// </summary>
        /// <param name="dbAccounts"></param>
        public AccountController(AccountDbContext dbAccounts)
        {
            this.dbAccounts = dbAccounts;
        }

        /// <summary>
        /// default page
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// HttpPost default page
        /// </summary>
        /// <param name="account"></param>
        /// <returns>redirects to ToDo Default page if login succeed
        /// else returns view</returns>
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

        /// <summary>
        /// HttpGet create page
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// HttpPost create page
        /// </summary>
        /// <param name="account"></param>
        /// <returns>redirects to default page if succeed
        /// else returns View</returns>
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
