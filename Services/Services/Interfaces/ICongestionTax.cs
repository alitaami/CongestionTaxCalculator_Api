using CongestionTAxCalculator_Project.Common.Enums;

namespace CongestionTaxCalculator_Project.Services.Interfaces
{
    public interface ICongestionTax
    {
        public Task<int> GetTax(VehicleTypes vehicle, DateTime[] dates, string cityName);
        public Task<bool> IsTollFreeVehicle(VehicleTypes vehicle, string cityName);
        public Task<int> GetTollFee(DateTime date, VehicleTypes vehicle, string cityName);
        public Task<Boolean> IsTollFreeDate(DateTime date, string cityName);
    }
}
