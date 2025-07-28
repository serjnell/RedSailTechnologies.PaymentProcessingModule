using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RedSailTechnologies.PaymentProcessingModule.Common.Models;
using RedSailTechnologies.PaymentProcessingModule.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedSailTechnologies.PaymentProcessingModule.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("daily_totals")]
    public class DailyTotalsController : ControllerBase
    {
        private readonly IDailyTotalsService _service;
        private readonly ILogger<DailyTotalsController> _logger;

        /// <summary>
        /// Initializes a new instance of a <see cref="DailyTotalsController"/>.
        /// </summary>
        /// <param name="service">The <see cref="IDailyTotalsService"/> service.</param>
        public DailyTotalsController(ILogger<DailyTotalsController> logger,
                                     IDailyTotalsService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Calculates daily totals.
        /// </summary>
        /// <param name="transactions">The transactions.</param>
        /// <returns>A nested dictionary where Key 1: currency, Key 2: date (only the day part), Value: total amount for that day and currency.</returns>
        [HttpGet("calculate")]
        public Dictionary<string, Dictionary<DateTime, decimal>> CalculateDailyTotals([FromBody] IEnumerable<Transaction> transactions)
        {
            try
            {
                return _service.CalculateDailyTotals(transactions);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return new Dictionary<string, Dictionary<DateTime, decimal>>();
            }
        }

        /// <summary>
        /// Calculates daily totals asynchronously.
        /// </summary>
        /// <param name="transactions">The transactions.</param>
        /// <returns>A nested dictionary where Key 1: currency, Key 2: date (only the day part), Value: total amount for that day and currency.</returns>
        [HttpGet("calculate_async")]
        public async Task<ActionResult<Dictionary<string, Dictionary<DateTime, decimal>>>> CalculateDailyTotalsAsync([FromBody] IEnumerable<Transaction> transactions)
        {
            try
            {
                return await _service.CalculateDailyTotalsAsync(transactions);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return BadRequest("Error occured during calculating daily totals.");
            }
        }
    }
}
