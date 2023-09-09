using Common.Utilities.Resources;
using CongestionTAxCalculator_Project.Data.Entities;
using CongestionTAxCalculator_Project.DB.CongestionTaxCalculatorApp.Data;
using CongestionTAxCalculator_Project.DB.Entities;
using CongestionTAxCalculator_Project.Services.Interfaces;
using Entities.Base;

namespace CongestionTAxCalculator_Project.Services
{
    public class TaxRuleLoder : ITaxRuleLoder
    {
        private readonly CongestionTaxContext _db;
        public TaxRuleLoder(CongestionTaxContext db)
        {
            _db = db;
        }

        public async Task<List<ExemptDaysOfWeek>> LoadDaysOfWeekForCity(string cityName)
        {
            try
            {
                int id = await TaxRuleId(cityName);

                var res = _db.ExemptDaysOfWeeks.Where(x => x.TaxRuleId == id).ToList();

                if (res.Count() == 0)
                    throw new AppException(Resource.NotFound);

                return res;
            }
            catch (Exception ex)
            {
                // Return an error response
                throw new AppException(ex.Message);
            }
        }
        public async Task<List<ExemptionDates>> LoadExemptionDatesForCity(string cityName)
        {
            try
            {
                int id = await TaxRuleId(cityName);
                var list = _db.ExemptionDates.Where(x => x.TaxRuleId == id).ToList();

                if (list.Count() == 0)
                    throw new AppException(Resource.NotFound);

                return list;
            }
            catch (Exception ex)
            {
                // Return an error response
                throw new AppException(ex.Message);
            }
        }
        public async Task<List<ExemptVehicleType>> LoadExemptVehiclesForCity(string cityName)
        {
            try
            {
                int id = await TaxRuleId(cityName);

                var res = _db.ExemptVehicleTypes.Where(x => x.TaxRuleId == id).ToList();

                if (res.Count() == 0)
                    throw new AppException(Resource.NotFound);

                return res;
            }
            catch (Exception ex)
            {
                // Return an error response
                throw new AppException(ex.Message);
            }
        }
        public async Task<List<TaxRule>> LoadRulesForCity(string cityName)
        {
            try
            {
                int id = await TaxRuleId(cityName);

                var taxRuleList = _db.TaxRules.Where(x => x.Id == id).ToList();

                if (taxRuleList.Count() == 0)
                    throw new AppException(Resource.NotFound);

                return taxRuleList;
            }
            catch (Exception ex)
            {
                // Return an error response
                throw new AppException(ex.Message);
            }
        }

        public async Task<List<TimeRangeTax>> LoadTimeRangesForCity(string cityName)
        {
            try
            {
                int id = await TaxRuleId(cityName);
                var list = _db.TimeRangeTaxes.Where(x => x.TaxRuleId == id).ToList();

                if (list.Count() == 0)
                    throw new AppException(Resource.NotFound);

                return list;
            }
            catch (Exception ex)
            {
                // Return an error response
                throw new AppException(ex.Message);
            }
        }
        public async Task<int> TaxRuleId(string cityName)
        {
            try
            {
                var city = _db.TaxRules.Where(c => c.City == cityName).FirstOrDefault();

                if (city == null)
                    throw new AppException(Resource.NotFound);

                else
                    return city.Id;

            }
            catch (Exception ex)
            {
                // Return an error response
                throw new AppException(ex.Message);
            }
        }
    }
}
