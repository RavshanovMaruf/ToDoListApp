using NUnit.Framework;
using To_Do_List_Application.Controllers;
using domain_entities;
using System.Reflection;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace todo_app_test
{
    [TestFixture]
    public class ToDoControllerTest
    {
        [Test]
        public void IndexView()
        {
            var itemListDbContext = ItemsListDbContext.ThisInstance;
            var controller = new ToDoController(itemListDbContext);
            var result = controller.Index() as ViewResult;
            
            Assert.AreEqual("Index", result.ViewName);
        }

        [Test]
        public void CreateView()
        {
            var itemListDbContext = ItemsListDbContext.ThisInstance;
            var controller = new ToDoController(itemListDbContext);
            var result = controller.Create() as ViewResult;
            
            Assert.AreEqual("Create", result.ViewName);
        }

        [Test]
        public void CreatePostView()
        {
            var itemListDbContext = ItemsListDbContext.ThisInstance;
            var controller = new ToDoController(itemListDbContext);
            var todoList = new ToDoList() {};
            var result = controller.Create(todoList) as ViewResult;
            //var product = (ToDoList)result.ViewData.Model;

            Assert.AreEqual("Create", result.ViewName);
            //Assert.AreEqual(null, product.Name);
        }

        [Test]
        public void DeleteView()
        {
            var itemListDbContext = ItemsListDbContext.ThisInstance;
            var controller = new ToDoController(itemListDbContext);
            var result = controller.Delete(3) as ViewResult;
            var product = (ToDoList)result.ViewData.Model;

            Assert.AreEqual("Delete", result.ViewName);
            Assert.AreEqual("WTF", product.Name);
            Assert.AreEqual(3, product.Id);
        }

        [Test]
        public void DeletePostView()
        {
            var itemListDbContext = ItemsListDbContext.ThisInstance;
            var controller = new ToDoController(itemListDbContext);
            var todoList = new ToDoList() { };
            var result = controller.Create(todoList) as ViewResult;


            Assert.AreEqual("Create", result.ViewName);
        }
    }
}