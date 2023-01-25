﻿namespace FoodDiary.Data.Entities
{
    public class Target
    {
        public int Id { get; set; }
        public User User { get; set; }
        
        public RelevanseType Relevanse { get; set; }
        public DateTime DateStart { get; set; }

        public DateTime DateFinish { get; set; }
        public double TargetBodyWeight { get; set; }

        public DailyRate DailyRate { get; set; }

    }
}