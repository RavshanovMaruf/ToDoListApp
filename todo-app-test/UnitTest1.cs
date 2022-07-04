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
    public class Tests : IDisposable
    {
        //private readonly ToDoDbContext db;
        //gg

        public void Dispose()
        {
            throw new NotImplementedException();//ToDoList.ClearAll();
        }

        //gitlab change

        [Test]
        public void CategoryConstructor_CreatesInstanceOfCategory_Category()
        {
            //ToDoList list = new ToDoList("test category");
            //Assert.AreEqual(typeof(ToDoList), list.GetType());
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