﻿using CongestionTAxCalculator_Project.DB.Entities;
using Entities.Models;

namespace CongestionTAxCalculator_Project.Services.Interfaces
{
    public interface ITaxRuleLoder
    {
        public Task<List<TaxRule>> LoadRulesForCity(string cityName);
        public Task<List<TimeRangeTax>> LoadTimeRangesForCity(string cityName);
        public Task<List<ExemptionDates>> LoadExemptionDatesForCity(string cityName);
        public Task<List<ExemptDaysOfWeek>> LoadExemptionDaysOfWeekForCity(string cityName);
        public Task<List<ExemptVehicleType>> LoadExemptVehiclesForCity(string cityName);
        public Task<int> TaxRuleId(string cityName);

    }
}
