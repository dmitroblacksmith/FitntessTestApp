using System;

namespace FitnessTestApp.BLL.Model
{
    [Serializable]
    public class Food
    {
        public string Name { get; set; }
        /// <summary>
        /// Белки
        /// </summary>
        public double Proteins { get; set; }

        /// <summary>
        /// Жиры
        /// </summary>
        public double Fats { get; set; }

        /// <summary>
        /// Углеводы
        /// </summary>
        public double Carbs { get; set; }

        /// <summary>
        /// Калории на 100 г продукта
        /// </summary>
        public double Calories { get; set; }

        public Food(string name) : this(name, 0, 0, 0,0) { }

        public Food(string name, double calories, double proteins, double fats, double carbs)
        {
            // TODO: проверка 

            Name = name;
            Calories = calories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbs = carbs / 100.0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}