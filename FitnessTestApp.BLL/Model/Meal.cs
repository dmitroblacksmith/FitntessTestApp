﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessTestApp.BLL.Model
{
    /// <summary>
    /// Прием пищи
    /// </summary>
    [Serializable]
    public class Meal
    {
        public DateTime Moment { get; set; }
        public Dictionary<Food, double> Foods { get; set; }
        public virtual User User { get; set; }

        public Meal(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым", nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            if(product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }
        }
    }
}