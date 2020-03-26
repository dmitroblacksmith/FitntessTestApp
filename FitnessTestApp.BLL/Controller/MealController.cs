using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using FitnessTestApp.BLL.Model;

namespace FitnessTestApp.BLL.Controller
{
    public class MealController : ControllerBase
    {
        private const string FOOD_FILE_NAME = "food.dat";
        private const string MEALS_FILE_NAME = "meal.dat";

        private readonly User user;
        public List<Food> Foods { get; }
        public Meal Meal { get; }

        public MealController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым", nameof(user));

            Foods = GetAllFoods();

            Meal = GetMeal();
        }
        
        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if(product == null)
            {
                Foods.Add(food);
                Meal.Add(food, weight);
                Save();
            }
            else
            {
                Meal.Add(product, weight);
                Save();
            }
        }

        private List<Food> GetAllFoods()
        {
            return Load<List<Food>>(FOOD_FILE_NAME) ?? new List<Food>();
        }

        private Meal GetMeal()
        {
            return Load<Meal>(MEALS_FILE_NAME) ?? new Meal(user);
        }

        public void Save()
        {
            Save(FOOD_FILE_NAME, Foods);
            Save(MEALS_FILE_NAME, Meal);
        }
    }
}