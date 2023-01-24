namespace FoodDiary.Data.Entities
{
    public class DailyRate
    {
        public int Id { get; set; }
        public Target Target { get; set; }
        public int TargetId { get; set; }

        public double CaloriesRate { get; set; }
        public double CarbohydrateRate { get; set; }
        public double FatRate { get; set; }
        public double ProteinRate { get; set; }


    }
}
