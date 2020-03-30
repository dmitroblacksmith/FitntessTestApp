﻿using System;

namespace FitnessTestApp.BLL.Model
{
    [Serializable]
    public class Exercise
    {
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public virtual Activity Activity { get; set; }
        public virtual User User { get; set; }

        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            // ПРОВЕРКА

            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }
    }
}