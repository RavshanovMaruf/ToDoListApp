using domain_entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace To_Do_List_Application.Controllers
{
    [Route("todo")]
    public class ToDoController : Controller
    {
        private readonly ILogger<ToDoController> _logger;
        private readonly ToDoDbContext _db;

        public ToDoController(ILogger<ToDoController> logger, ToDoDbContext db)
        {
            _logger = logger;
            _db = db;
        }
        public ActionResult Index()
        {
            var results = _db.ToDoList.ToList();
            return View(results);
        }

        /*public string OpenPopup()
        {
            return "<h1> This Is Modeless Popup Window</h1>";
        }*/

        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        public ActionResult Create(ToDoList list)
        {
            _db.Add(list);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Route("delete")]
        public ActionResult Delete(int id)
        {
            var item = _db.ToDoList.Where(x => x.Id == id).FirstOrDefault();
            return View(item);
        }

        [HttpPost]
        [Route("delete")]
        public ActionResult Delete(ToDoList list)
        {
            _db.ToDoList.Remove(list);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}