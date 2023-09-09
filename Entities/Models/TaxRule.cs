 using Entities.Models;

namespace CongestionTAxCalculator_Project.DB.Entities
{
    public class TaxRule
    {
        public int Id { get; set; }
        public string City { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // relations
        public ICollection<ExemptDaysOfWeek> ExemptDaysOfWeek { get; set; } = new List<ExemptDaysOfWeek>();
        public ICollection<ExemptVehicleType> ExemptVehicleTypes { get; set; } = new List<ExemptVehicleType>();
        public ICollection<TimeRangeTax> TimeRanges { get; set; } = new List<TimeRangeTax>();
        public ICollection<ExemptionDates> ExemptionDates { get; set; } = new List<ExemptionDates>();

    }
}
