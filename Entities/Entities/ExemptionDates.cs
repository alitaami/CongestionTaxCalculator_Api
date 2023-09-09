namespace CongestionTAxCalculator_Project.Data.Entities
{
    public class ExemptionDates
    {
        public int Id { get; set; }
        public DateTime dateTime { get; set; }
        public int TaxRuleId { get; set; }
    }
}
