using domain_entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using To_Do_List_Application.Models;

namespace To_Do_List_Application.Controllers
{

    public class HomeController : Controller
    {
        private readonly AccountDbContext dbAccounts;
        //public static HomeController ThisInstance = null;

        /// <summary>
        /// Gets AccountDbContext
        /// </summary>
        /// <param name="dbAccounts"></param>
        public HomeController(AccountDbContext dbAccounts)
        {
            this.dbAccounts = dbAccounts;
            //ThisInstance = this;
        }

        /// <summary>
        /// default page
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Index()
        {
            return View("Index");
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
            return View("Index");
        }

        /// <summary>
        /// HttpGet create page
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Create()
        {
            return View("Create");
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
