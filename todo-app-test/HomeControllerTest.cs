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
    public class HomeControllerTest
    {
        [Test]
        public void IndexView()
        {
            var accountDbContext = AccountDbContext.ThisInstance;
            var controller = new HomeController(accountDbContext);
            var result = controller.Index() as ViewResult;
            if (result == null)
            {
                Assert.AreEqual(null, result.ViewName);
            }
            else
                Assert.AreEqual("Index", result.ViewName);
        }

        [Test]
        public void IndexPostView()
        {
            var accountDbContext = AccountDbContext.ThisInstance;
            var controller = new HomeController(accountDbContext);
            var account = new Account() { };
            var result = controller.Index(account) as ViewResult;
            
            Assert.AreEqual("Index", result.ViewName);
        }

        [Test]
        public void CreateView()
        {
            var accountDbContext = AccountDbContext.ThisInstance;
            var controller = new HomeController(accountDbContext);
            var result = controller.Create() as ViewResult;
            if (result == null)
            {
                Assert.AreEqual(null, result.ViewName);
            }
            else
                Assert.AreEqual("Create", result.ViewName);
        }

        [Test]
        public void CreatePostView()
        {
            var accountDbContext = AccountDbContext.ThisInstance;
            var controller = new HomeController(accountDbContext);
            var account = new Account() {};
            var result = controller.Create(account) as ViewResult;
            var product = (Account)result.ViewData.Model;

            Assert.AreEqual(null, result.ViewName);
            Assert.AreEqual(null, product.Login);
            Assert.AreEqual(null, product.Password);
        }
    }
}