namespace Entities.Models
{
    public class ExemptDaysOfWeek
    {
        public int Id { get; set; }
        public DayOfWeek DaysOfWeek { get; set; }
        public int TaxRuleId { get; set; }
    }
}
