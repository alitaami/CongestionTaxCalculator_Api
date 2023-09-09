using CongestionTAxCalculator_Project.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Entities.ViewMoodels
{
    public class CongestionTaxRequest
    {
        [Required]
        public VehicleTypes VehicleType { get; set; }
        [Required]
        public string CityName { get; set; }
        [Required]
        public string[] DateStrings { get; set; }
    }
}
