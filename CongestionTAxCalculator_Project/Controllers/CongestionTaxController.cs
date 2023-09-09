using CongestionTaxCalculator_Project.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Common.Utilities.Resources;
using Entities.Base;
using Entities.ViewMoodels;

namespace CongestionTAxCalculator_Project.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CongestionTaxController : ControllerBase
    {
        private readonly ICongestionTax _congestionTax;
        private readonly ILogger<CongestionTaxController> _logger;

        public CongestionTaxController(ICongestionTax congestionTax, ILogger<CongestionTaxController> logger)
        {
            _congestionTax = congestionTax;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CalculateCongestionTax([FromBody] CongestionTaxRequest request)
        {
            try
            {
                // Convert date strings to DateTime objects
                DateTime[] dates = request.DateStrings.Select(dateString => DateTime.Parse(dateString)).ToArray();

                // Call the GetTax method 
                int congestionTax = await _congestionTax.GetTax(request.VehicleType, dates, request.CityName);

                if (congestionTax < 0)
                    throw new AppException(Resource.EnterParametersCorrectlyAndCompletely);

                // Return the calculated congestion tax as JSON
                return Ok(new { CongestionTaxValue = congestionTax });
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                _logger.LogError(ex, Resource.InternalServerError);

                // Return an error response
                return StatusCode(500, Resource.InternalServerError);
            }
        }
    }
}
