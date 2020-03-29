using System;
using System.Globalization;
using System.Resources;
using FitnessTestApp.BLL.Controller;
using FitnessTestApp.BLL.Model;

namespace FitnessTestApp.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("ru-ru");
            var resourceManager = new ResourceManager("FitnessTestApp.CLI.Languages.Messages", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Hello", culture));

            Console.Write(resourceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var mealController = new MealController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.Write(resourceManager.GetString("EnterGender", culture));
                var genderName = Console.ReadLine();
                var birthDate = ParseDateTime("дата рождения");
                var weight = ParseDouble("вес");
                var height = ParseDouble("рост");

                userController.SetNewUserData(genderName, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);

            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("M - ввести прием пищи");
                Console.WriteLine("A - ввести упражнение");
                Console.WriteLine("Q - выход");
                var key = Console.ReadKey();
                Console.WriteLine();


                switch (key.Key)
                {
                    case ConsoleKey.M:
                        var food = EnterMeal();
                        mealController.Add(food.Food, food.Weight);

                        foreach (var item in mealController.Meal.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }

                        break;
                    case ConsoleKey.A:
                        var exercise = EnterExercise();
                        exerciseController.Add(exercise.Activity, exercise.Start, exercise.Finish);

                        foreach(var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity.Name} c {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                        }

                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }

                Console.ReadLine();
            }
        }

        private static (DateTime Start, DateTime Finish, Activity Activity) EnterExercise()
        {
            Console.Write("Введите название упражнения: ");
            var name = Console.ReadLine();

            var energy = ParseDouble("расход энергии в минуту");

            var start = ParseDateTime("начало упражнения");
            var finish = ParseDateTime("окончание упражнения");

            var activity = new Activity(name, energy);
            return (Start: start, Finish: finish, Activity: activity);
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

        private static DateTime ParseDateTime(string value)
        {
            while (true)
            {
                Console.Write($"Введите {value} (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                {
                    return date;
                }
                else
                {
                    Console.WriteLine($"Неверный формат поля {value}");
                }
            }
        }
    }
}
