using FoodDiary.Data.Entities;

namespace FoodDiary.ViewModels.User
{
    public class DailyRateViewModel
    {
        public int Id { get; set; }
        public double CaloriesRate { get; set; }
        public double CarbohydrateRate { get; set; }
        public double FatRate { get; set; }
        public double ProteinRate { get; set; }
    }
}
