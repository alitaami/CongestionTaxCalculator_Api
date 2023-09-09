namespace Entities.Models
{
    public class ExemptionDates
    {
        public int Id { get; set; }
        public DateTime dateTime { get; set; }
        public int TaxRuleId { get; set; }
    }
}
