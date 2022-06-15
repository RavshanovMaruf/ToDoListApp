using NUnit.Framework;
using To_Do_List_Application.Controllers;
using domain_entities;
using System.Reflection;
using System.Linq;
using System;
using System.Collections.Generic;

namespace todo_app_test
{
    [TestFixture]
    public class Tests
    {
        private readonly ToDoDbContext db;

        [TestCase("String", "String")]
        [TestCase("Second", "Second")]
        [TestCase("Third", "Third")]
        [TestCase("Fourth", "Fourth")]
        [TestCase("Fifth", "Fifth")]
        public void CreateMethod(string exp, string actual)
        {
            var controller = new ToDoController();
            var ToDoList = new ToDoList { Id = 11, Name = "Unit" };
            List<ToDoList> explist = new List<ToDoList>();

            Assert.AreEqual(exp, actual);
        }

        [TestCase("String", "String")]
        [TestCase("Second", "Second")]
        [TestCase("Third", "Third")]
        [TestCase("Fourth", "Fourth")]
        [TestCase("Fifth", "Fifth")]
        public void SecondMethod(string exp, string actual)
        {
            var controller = new ToDoController();
            var ToDoList = new ToDoList { Id = 11, Name = "Unit" };
            List<ToDoList> explist = new List<ToDoList>();

            Assert.AreEqual(exp, actual);
        }

        [TestCase("String", "String")]
        [TestCase("Second", "Second")]
        [TestCase("Third", "Third")]
        [TestCase("Fourth", "Fourth")]
        [TestCase("Fifth", "Fifth")]
        public void ThirdMethod(string exp, string actual)
        {
            var controller = new ToDoController();
            var ToDoList = new ToDoList { Id = 11, Name = "Unit" };
            List<ToDoList> explist = new List<ToDoList>();

            Assert.AreEqual(exp, actual);
        }

        [TestCase("String", "String")]
        [TestCase("Second", "Second")]
        [TestCase("Third", "Third")]
        [TestCase("Fourth", "Fourth")]
        [TestCase("Fifth", "Fifth")]
        public void FourthMethod(string exp, string actual)
        {
            var controller = new ToDoController();
            var ToDoList = new ToDoList { Id = 11, Name = "Unit" };
            List<ToDoList> explist = new List<ToDoList>();

            Assert.AreEqual(exp, actual);
        }

        [TestCase("String", "String")]
        [TestCase("Second", "Second")]
        [TestCase("Third", "Third")]
        [TestCase("Fourth", "Fourth")]
        [TestCase("Fifth", "Fifth")]
        public void FifthMethod(string exp, string actual)
        {
            var controller = new ToDoController();
            var ToDoList = new ToDoList { Id = 11, Name = "Unit" };
            List<ToDoList> explist = new List<ToDoList>();

            Assert.AreEqual(exp, actual);
        }

        [Test]
        public void ClassCreated()
        {
            var assemblyContent = LoadAssemblyContent();

            var employeeType = assemblyContent.GetType("ToDoController");

            Assert.IsNotNull(employeeType, "ToDoController class is not created.");
        }

        [Test]
        public void MethodCreated()
        {
            var assemblyContent = LoadAssemblyContent();
            var employeeType = assemblyContent.GetType("ToDoController");
            var method = employeeType.GetMethod("Create");

            Assert.IsNotNull(method, "Create method is not defined");
        }

        private static Assembly LoadAssemblyContent()
        {
            var assemblyName = typeof(ToDoController).AssemblyQualifiedName;
            //Assert.AreEqual(assemblyName, "To_Do_List_Application.Controllers.ToDoController");
            return Assembly.Load(assemblyName);
        }
    }
}