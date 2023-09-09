using CongestionTAxCalculator_Project.Data.Entities;
using CongestionTAxCalculator_Project.DB.Entities;

namespace CongestionTAxCalculator_Project.Services.Interfaces
{
    public interface ITaxRuleLoder
    {
        public Task<List<TaxRule>> LoadRulesForCity(string cityName);
        public Task<List<TimeRangeTax>> LoadTimeRangesForCity(string cityName);
        public Task<List<ExemptionDates>> LoadExemptionDatesForCity(string cityName);
        public Task<List<ExemptDaysOfWeek>> LoadDaysOfWeekForCity(string cityName);
        public Task<List<ExemptVehicleType>> LoadExemptVehiclesForCity(string cityName);
        public Task<int> TaxRuleId(string cityName);

    }
}
