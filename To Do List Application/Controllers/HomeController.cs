﻿using domain_entities;
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
        private readonly ILogger<HomeController> _logger;
        private readonly ToDoDbContext _db;

        public HomeController(ILogger<HomeController> logger, ToDoDbContext db)
        {
            _logger = logger;
            _db = db;
        }
        public ActionResult Index()
        {
            var results = _db.ToDoList.ToList();
            return View(results);
        }

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