using System;
using FitnessTestApp.BLL.Controller;
using FitnessTestApp.BLL.Model;

namespace FitnessTestApp.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение FintessTestApp");

            Console.Write("Введите имя пользователя: ");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var mealController = new MealController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var genderName = Console.ReadLine();
                var birthDate = ParseDateTime();
                var weight = ParseDouble("вес");
                var height = ParseDouble("рост");

                userController.SetNewUserData(genderName, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("M - ввести прием пищи");
            var key = Console.ReadKey();
            Console.WriteLine();

            if (key.Key == ConsoleKey.M)
            {
                var food = EnterMeal();
                mealController.Add(food.Food, food.Weight);

                foreach( var item in mealController.Meal.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }


            Console.ReadLine();
        }

        private static (Food Food, double Weight) EnterMeal()
        {
            Console.Write("Введите имя продукта:");
            var product = Console.ReadLine();

            var calories = ParseDouble("калорийность");

            var proteins = ParseDouble("белки");

            var fats = ParseDouble("жиры");

            var carbs = ParseDouble("углеводы");

            var weight = ParseDouble("вес порции");
            var food = new Food(product, calories, proteins, fats, carbs);

            return (Food: food, Weight: weight);
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат поля {name}");
                }
            }
        }

        private static DateTime ParseDateTime()
        {
            while (true)
            {
                Console.Write("Введите дату рождения (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
                {
                    return birthDate;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты рождения");
                }
            }
        }
    }
}
