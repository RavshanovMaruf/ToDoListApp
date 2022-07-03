using domain_entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace To_Do_List_Application.Controllers
{
    [Route("todo")]
    public class ToDoController : Controller
    {
        private readonly ILogger<ToDoController> _logger;

        private readonly ItemsListDbContext _dbItemsList;

        /// <summary>
        /// Constructor to get logger and database context
        /// </summary>
        public ToDoController(ILogger<ToDoController> logger, /*ToDoDbContext db,*/ ItemsListDbContext dbItemsList)
        {
            _logger = logger;
            _dbItemsList = dbItemsList;
        }

        /// <summary>
        /// Default page.
        /// </summary>
        /// <returns>
        /// returns view with list of todos.
        /// </returns>
        public ActionResult Index()
        {
            var model = _dbItemsList.Lists.ToList();
            return View(model);
        }

        /// <summary>
        /// Create page.
        /// </summary>
        /// <returns>
        /// returns view .
        /// </returns>
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// HttpPost  Create page.
        /// </summary>
        /// <returns>
        /// redirects to default page .
        /// </returns>
        [HttpPost]
        [Route("create")]
        public ActionResult Create(ToDoList list)
        {
            _dbItemsList.Lists.Add(list);
            _dbItemsList.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// HttpGet  Delete page.
        /// </summary>
        /// <returns>
        /// returns view with deleting list.
        /// </returns>
        [Route("delete")]
        public ActionResult Delete(int id)
        {
            var item = _dbItemsList.Lists.Where(x => x.Id == id).FirstOrDefault();
            return View(item);
        }

        /// <summary>
        /// HttpPost  Delete page.
        /// </summary>
        /// <returns>
        /// redirects to default page.
        /// </returns>
        [HttpPost]
        [Route("delete")]
        public ActionResult Delete(ToDoList list)
        {
            _dbItemsList.Lists.Remove(list);
            _dbItemsList.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}