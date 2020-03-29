using System;

namespace FitnessTestApp.BLL.Model
{
    [Serializable]
    public class Activity
    {
        public string Name { get; }

        public double CalloriesPerMinute { get; }

        public Activity(string name, double calloriesPerMinute)
        {
            // ПРОВЕРКА

            Name = name;
            CalloriesPerMinute = calloriesPerMinute;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}