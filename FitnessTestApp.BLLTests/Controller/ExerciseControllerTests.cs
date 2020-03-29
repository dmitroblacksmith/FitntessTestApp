using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitnessTestApp.BLL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FitnessTestApp.BLL.Model;

namespace FitnessTestApp.BLL.Controller.Tests
{
    [TestClass()]
    public class ExerciseControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arange
            var userName = Guid.NewGuid().ToString();
            var activityName = Guid.NewGuid().ToString();
            var rand = new Random();
            var userController = new UserController(userName);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            var activity = new Activity(activityName, rand.Next(10, 50));

            //Act
            exerciseController.Add(activity, DateTime.Now, DateTime.Now.AddHours(1));

            //Assert
            Assert.AreEqual(activityName, exerciseController.Activities.First().Name);
        }
    }
}