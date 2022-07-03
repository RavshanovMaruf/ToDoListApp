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
        //private readonly ToDoDbContext db;
        //private readonly ToDoItemsDbContext dbItems;
        private readonly ItemsListDbContext _dbListItems;

        public ToDoitemsController(ItemsListDbContext dbItemsList/*, ToDoDbContext db, ToDoItemsDbContext dbItems*/)
        {
            _dbListItems = dbItemsList;
            //this.db = db;
            //this.dbItems = dbItems;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Index(ToDoList list)//ItemsList list)
        {
            var items = _dbListItems.Items;
            List<ToDoItems> res = new List<ToDoItems>();
            
            res = _dbListItems.Items.Where(x => x.ListName == list.Name).ToList();
            
            if (res.Count != 0)
                return View(res);
            else
                return Redirect("/todoitems/empty");
            /*
            var items = dbItems.ToDoItem;
            List<ToDoItems> res = new List<ToDoItems>();

            res = dbItems.ToDoItem.Where(x => x.ListName == list.Name).ToList();
            
            foreach(ToDoItems item in res)
            {
                if (item.DueDate == DateTime.Today)
                {
                    Console.WriteLine("Today");
                }
            }
            
            if (res.Count != 0)
                return View(res);
            else
                return Redirect("/todoitems/empty");
            */
        }

        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

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
            /*
            if (!string.IsNullOrWhiteSpace(item.Title)
                && !string.IsNullOrWhiteSpace(item.ListName)
                && item.Status >=0 && item.Status <= 2)
            {
                dbItems.Add(item);
                dbItems.SaveChanges();
                return Redirect("/todo");
            }
            return View(item);*/
        }

        [Route("edit")]
        public ActionResult Edit(int id)
        {
            var item = _dbListItems.Items.Where(x => x.Id == id).FirstOrDefault();
            return View(item);
            /*
            var item = dbItems.ToDoItem.Where(x => x.Id == id).FirstOrDefault();
            return View(item);*/
        }

        [HttpPost]
        [Route("edit")]
        public ActionResult Edit(ToDoItems item)
        {
            _dbListItems.Update(item);
            _dbListItems.SaveChanges();
            return Redirect("/todo");
            /*
            dbItems.Update(item);
            dbItems.SaveChanges();
            return Redirect("/todo");*/
        }

        [Route("delete")]
        public ActionResult Delete(int id)
        {
            var item = _dbListItems.Items.Where(x => x.Id == id).FirstOrDefault();
            return View(item);
            /*
            var item = dbItems.ToDoItem.Where(x => x.Id == id).FirstOrDefault();
            return View(item);*/
        }

        [Route("deleteconfirm")]
        public ActionResult DeleteConfirm(int id)
        {
            var item = _dbListItems.Items.Where(x => x.Id == id).First();
            _dbListItems.Items.Remove(item);
            _dbListItems.SaveChanges();
            return Redirect("/todo");
            /*
            var item = dbItems.ToDoItem.Where(x => x.Id == id).First();
            dbItems.ToDoItem.Remove(item);
            dbItems.SaveChanges();
            return Redirect("/todo");*/
        }
        [Route("empty")]
        public ActionResult Empty()
        {
            return View();
        }
    }
}
