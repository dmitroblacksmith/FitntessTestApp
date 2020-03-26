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
    public class MealControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arange
            var userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
            var rand = new Random();
            var userController = new UserController(userName);
            var mealController = new MealController(userController.CurrentUser);
            var food = new Food(foodName, rand.Next(50,500), rand.Next(50, 500), rand.Next(50, 500), rand.Next(50, 500));

            //Act
            mealController.Add(food, 100);

            //Assert
            Assert.AreEqual(food.Name, mealController.Meal.Foods.First().Key.Name);
        }
    }
}