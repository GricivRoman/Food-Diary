using FoodDiary.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDiary.ViewModels.User
{
    public class TargetViewModel
    {
        public int Id { get; set; }        
        public bool relevance { get; set; }
        public DateTime DateStart { get; set; }

        public DateTime DateFinish { get; set; }
        public double TargetBodyWeight { get; set; }

        public DailyRateViewModel DailyRate { get; set; }       
    }
}
