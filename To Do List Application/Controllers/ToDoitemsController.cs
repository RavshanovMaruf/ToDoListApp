using domain_entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace To_Do_List_Application.Controllers
{
    [Route("todoitems")]
    public class ToDoitemsController : Controller
    {
        private readonly ItemsListDbContext _dbListItems;

        /// <summary>
        /// Constructor to get database context
        /// </summary>
        public ToDoitemsController(ItemsListDbContext dbItemsList)
        {
            _dbListItems = dbItemsList;
        }

        /// <summary>
        /// Default page.
        /// </summary>
        /// <returns>
        /// returns view with items.
        /// </returns>
        [HttpGet]
        [Route("")]
        public ActionResult Index(ToDoList list)
        {
            var items = _dbListItems.Items;
            List<ToDoItems> res = new List<ToDoItems>();
            
            res = _dbListItems.Items.Where(x => x.ListName == list.Name).ToList();
            
            if (res.Count != 0)
                return View(res);
            else
                return Redirect("/todoitems/empty");
        }

        /// <summary>
        /// Create page.
        /// </summary>
        /// <returns>
        /// returns view.
        /// </returns>
        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// HttpPost  Create page.
        /// </summary>
        /// <returns>
        /// redirects to default page if title, listName and status is not null.
        /// else returns create view
        /// </returns>
        [HttpPost]
        [Route("create")]
        public ActionResult Create(ToDoItems item)
        {
            if (!string.IsNullOrWhiteSpace(item.Title)
                && !string.IsNullOrWhiteSpace(item.ListName)
                && item.Status >= 0 && item.Status <= 2)
            {
                _dbListItems.Add(item);
                _dbListItems.SaveChanges();
                return Redirect("/todo");
            }
            return View(item);
        }

        /// <summary>
        /// HttpGet  Edit page.
        /// </summary>
        /// <returns>
        /// returns view with editing list.
        /// </returns>
        [Route("edit")]
        public ActionResult Edit(int id)
        {
            var item = _dbListItems.Items.Where(x => x.Id == id).FirstOrDefault();
            return View(item);
        }

        /// <summary>
        /// HttpPost  Edit page.
        /// </summary>
        /// <returns>
        /// redirects to default page if title, listnames are not null
        /// else returns view with editing list.
        /// </returns>
        [HttpPost]
        [Route("edit")]
        public ActionResult Edit(ToDoItems item)
        {
            if (!string.IsNullOrWhiteSpace(item.Title)
                && !string.IsNullOrWhiteSpace(item.ListName)
                && item.Status >= 0 && item.Status <= 2)
            {
                _dbListItems.Update(item);
                _dbListItems.SaveChanges();

                return Redirect("/todo");
            }
            return View(item);
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
            var item = _dbListItems.Items.Where(x => x.Id == id).FirstOrDefault();
            return View(item);
        }

        /// <summary>
        /// HttpPost  Delete page.
        /// </summary>
        /// <returns>
        /// redirects to default page.
        /// </returns>
        [Route("deleteconfirm")]
        public ActionResult DeleteConfirm(int id)
        {
            var item = _dbListItems.Items.Where(x => x.Id == id).First();
            _dbListItems.Items.Remove(item);
            _dbListItems.SaveChanges();
            return Redirect("/todo");
        }

        /// <summary>
        /// if there is no items in the list
        /// </summary>
        /// <returns>
        /// returns view
        /// </returns>
        [Route("empty")]
        public ActionResult Empty()
        {
            return View();
        }
    }
}
