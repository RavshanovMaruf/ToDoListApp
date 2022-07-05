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
    public class ToDoItemsControllerTest
    {
        [Test]
        public void IndexView()
        {
            var itemListDbContext = ItemsListDbContext.ThisInstance;
            var controller = new ToDoitemsController(itemListDbContext);
            var todoList = new ToDoList();
            var result = controller.Index(todoList) as ViewResult;
            
            Assert.AreEqual("Index", result.ViewName);
        }

        [Test]
        public void CreateView()
        {
            var itemListDbContext = ItemsListDbContext.ThisInstance;
            var controller = new ToDoitemsController(itemListDbContext);
            var result = controller.Create() as ViewResult;
            
            Assert.AreEqual("Create", result.ViewName);
        }

        [Test]
        public void CreatePostView()
        {
            var itemListDbContext = ItemsListDbContext.ThisInstance;
            var controller = new ToDoitemsController(itemListDbContext);
            var item = new ToDoItems() {};
            var result = controller.Create(item) as ViewResult;
            var product = (ToDoItems)result.ViewData.Model;

            Assert.AreEqual("Create", result.ViewName);
            Assert.AreEqual(null, product.Title);
            Assert.AreEqual(null, product.Description);
            Assert.AreEqual(null, product.ListName);
            Assert.AreEqual(0, product.Status);
        }

        [Test]
        public void EditView()
        {
            var itemListDbContext = ItemsListDbContext.ThisInstance;
            var controller = new ToDoitemsController(itemListDbContext);
            var result = controller.Edit(4) as ViewResult;

            Assert.AreEqual("Edit", result.ViewName);
        }

        [Test]
        public void EditPostView()
        {
            var itemListDbContext = ItemsListDbContext.ThisInstance;
            var controller = new ToDoitemsController(itemListDbContext);
            var item = new ToDoItems();
            var result = controller.Edit(item) as ViewResult;
            var product = (ToDoItems)result.ViewData.Model;

            Assert.AreEqual("Edit", result.ViewName);
            Assert.AreEqual(null, product.ListName);
            Assert.AreEqual(null, product.Title);
            Assert.AreEqual(null, product.Description);
            Assert.AreEqual(0, product.Status);
        }

        [Test]
        public void DeleteView()
        {
            var itemListDbContext = ItemsListDbContext.ThisInstance;
            var controller = new ToDoitemsController(itemListDbContext);
            var result = controller.Delete(3) as ViewResult;

            Assert.AreEqual("Delete", result.ViewName);
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

        [Test]
        public void EmptyView()
        {
            var itemListDbContext = ItemsListDbContext.ThisInstance;
            var controller = new ToDoitemsController(itemListDbContext);
            var result = controller.Empty() as ViewResult;

            Assert.AreEqual("Empty", result.ViewName);
        }
    }
}