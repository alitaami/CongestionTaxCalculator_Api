using CongestionTAxCalculator_Project.Common.Enums;

namespace Entities.Models
{
    public class ExemptVehicleType
    {
        public int Id { get; set; }
        public VehicleTypes TollFreeVehicles { get; set; }
        public int TaxRuleId { get; set; }
    }
}
