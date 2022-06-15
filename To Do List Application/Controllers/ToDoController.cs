using domain_entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace To_Do_List_Application.Controllers
{
    [Route("todo")]
    public class ToDoController : Controller
    {
        private readonly ToDoDbContext _db;

        public ToDoController(ToDoDbContext db)
        {
            _db = db;
        }

        public ToDoController()
        {
        }

        public ActionResult Index()
        {
            var results = _db.ToDoList.ToList();
            return View(results);
        }

        /*[Route("create")]
        public ActionResult Create()
        {
            return View();
        }*/

        //[HttpPost]
        [Route("create")]
        public IActionResult Create(ToDoList list)
        {
            _db.ToDoList.Add(list);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Route("list")]
        public IActionResult List()
        {
            var results = _db.ToDoList.ToList();
            return View(results);
        }

        [Route("delete")]
        public ActionResult Delete(int id)
        {
            var item = _db.ToDoList.Where(x => x.Id == id).FirstOrDefault();
            return View(item);
        }
    }
}
