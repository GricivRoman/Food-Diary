using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDiary.Data.Entities
{
    public class Target
    {
        public int Id { get; set; }
        public User User { get; set; }        
        
        public bool relevance { get; set; }
        public DateTime DateStart { get; set; }

        public DateTime DateFinish { get; set; }
        public double TargetBodyWeight { get; set; }

        public DailyRate DailyRate { get; set; }
        
        [ForeignKey(nameof(DailyRate))]
        public int DailyRateId { get; set; }

    }
}
