namespace CongestionTAxCalculator_Project.DB.Entities
{
    public class TimeRangeTax
    {
        public int Id { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int TaxAmount { get; set; }
        public int TaxRuleId { get; set; }

    }
}
