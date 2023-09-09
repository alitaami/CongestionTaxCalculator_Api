namespace CongestionTAxCalculator_Project.Data.Entities
{
    public class ExemptDaysOfWeek
    {
        public int Id { get; set; }
        public DayOfWeek DaysOfWeek { get; set; }
        public int TaxRuleId { get; set; }
    }
}
