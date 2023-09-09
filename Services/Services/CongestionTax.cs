using Common.Utilities.Resources;
using CongestionTaxCalculator_Project.Services.Interfaces;
using CongestionTAxCalculator_Project.Common.Enums;
using CongestionTAxCalculator_Project.Services.Interfaces;
using Entities.Base;

namespace CongestionTaxCalculator_Project.Services
{
    public class CongestionTax : ICongestionTax
    {
        private readonly ITaxRuleLoder _load;
        public CongestionTax(ITaxRuleLoder load)
        {
            _load = load;
        }

        public async Task<int> GetTax(VehicleTypes vehicle, DateTime[] dates, string cityName)
        {
            try
            {
                int totalFee = 0;
                DateTime startDate = dates[0];
                int tempFee = 0;

                foreach (DateTime date in dates)
                {
                    int nextFee = await GetTollFee(date, vehicle, cityName);

                    // Calculate the time difference in minutes
                    long minutesDifference = (long)(date - startDate).TotalMinutes;

                    if (minutesDifference <= 60)
                    {
                        // Update tempFee with the higher fee if needed
                        tempFee = Math.Max(tempFee, nextFee);
                    }
                    else
                    {
                        // Add the highest fee within the 60-minute window to totalFee
                        totalFee += tempFee;

                        // Reset startDate and tempFee for the next 60-minute window
                        startDate = date;
                        tempFee = nextFee;
                    }
                }
                // Add the last highest fee within the 60-minute window
                totalFee += tempFee;

                // Ensure totalFee does not exceed 60
                return Math.Min(totalFee, 60);
            }
            catch (Exception ex)
            {
                // Return an error response
                throw new AppException(ex.Message);
            }
        }
        public async Task<int> GetTollFee(DateTime date, VehicleTypes vehicle, string cityName)
        {
            try
            {
                if (await IsTollFreeDate(date, cityName) || await IsTollFreeVehicle(vehicle, cityName)) return 0;

                int hour = date.Hour;
                int minute = date.Minute;

                var list = await _load.LoadTimeRangesForCity(cityName);

                var res = list.Where(x => (hour > x.StartTime.Hours ||
                (hour == x.StartTime.Hours && minute >= x.StartTime.Minutes)) &&
                (hour < x.EndTime.Hours || (hour == x.EndTime.Hours && minute <= x.EndTime.Minutes)))
                .OrderByDescending(x => x.StartTime.Hours)
                .FirstOrDefault();

                if (res != null)
                    return res.TaxAmount;

                else
                    return 0;

                #region OldCodes

                /*
                Dictionary<(int, int), int> intervalToFee = new Dictionary<(int, int), int>
            {
             {(6, 0), 8},
             {(6, 30), 13},
             {(7, 0), 18},
             {(8, 0), 13},
             {(15, 0), 13},
             {(15, 30), 18},
             {(17, 0), 13},
             {(18, 0), 8}
             };

                // Find the appropriate fee based on the hour and minute
                var interval = intervalToFee.Keys
                    .Where(key => hour > key.Item1 || (hour == key.Item1 && minute >= key.Item2))
                    .OrderByDescending(key => key.Item1)
                    .ThenByDescending(key => key.Item2)
                    .FirstOrDefault();

                // Get the fee from the dictionary
                if (intervalToFee.TryGetValue(interval, out int fee))
                {
                    // return the tax fee
                    return fee;
                }

                return 0;
                */

                #endregion
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }
        public async Task<bool> IsTollFreeDate(DateTime date, string cityName)
        {
            try
            {
                var days = await _load.LoadExemptionDaysOfWeekForCity(cityName);
                var dates = await _load.LoadExemptionDatesForCity(cityName);

                if (days.Any(x => x.DaysOfWeek.Equals(date.DayOfWeek)))
                {
                    return true;
                }
                else
                {
                    return dates.Any(x => x.dateTime.Date.Equals(date.Date));
                }

                #region OldCodes

                /*

                // Check if it's a weekend (Saturday or Sunday)
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    return true;
                }

                // Define a list of specific toll-free dates for the year 2013
                List<DateTime> tollFreeDatesOf2013 = new List<DateTime>
                {
                    new DateTime(2013, 1, 1),
                    new DateTime(2013, 3, 28),
                    new DateTime(2013, 3, 29),
                    new DateTime(2013, 4, 1),
                    new DateTime(2013, 4, 30),
                    new DateTime(2013, 5, 1),
                    new DateTime(2013, 5, 9),
                    new DateTime(2013, 5, 8),
                    new DateTime(2013, 6, 5),
                    new DateTime(2013, 6, 6),
                    new DateTime(2013, 6, 21),
                    new DateTime(2013, 7, 1),
                    new DateTime(2013, 11, 1),
                    new DateTime(2013, 12, 24),
                    new DateTime(2013, 12, 25),
                    new DateTime(2013, 12, 26),
                    new DateTime(2013, 12, 31)
                };

                // Check if the provided date is in the list of toll-free dates
                return tollFreeDatesOf2013.Contains(date.Date);
                #endregion

                */

                #endregion
            }
            catch (Exception ex)
            {
                // Return an error response
                throw new AppException(ex.Message);
            }
        }
        public async Task<bool> IsTollFreeVehicle(VehicleTypes vehicle, string cityName)
        {
            try
            {
                if (vehicle == null)
                    throw new AppException(Resource.NotFound);

                var list = await _load.LoadExemptVehiclesForCity(cityName);

                // Check if the vehicle type exists in the list of exempt vehicle types 
                return list.Any(item => item.TollFreeVehicles.Equals(vehicle));

                #region OldCodes
                /*
                                HashSet<string> tollFreeVehicleTypes = new HashSet<string>()
                            {
                             TollFreeVehicles.Motorcycle.ToString(),
                             TollFreeVehicles.Tractor.ToString(),
                             TollFreeVehicles.Emergency.ToString(),
                             TollFreeVehicles.Diplomat.ToString(),
                             TollFreeVehicles.Foreign.ToString(),
                             TollFreeVehicles.Military.ToString(),
                            };

                                return tollFreeVehicleTypes.Contains(vehicle.GetVehicleType());
                */
                #endregion
            }
            catch (Exception ex)
            {
                // Return an error response
                throw new AppException(ex.Message);
            }
        }
    }
}
