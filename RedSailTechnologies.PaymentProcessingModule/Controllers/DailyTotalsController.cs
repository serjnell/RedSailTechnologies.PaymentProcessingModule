using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RedSailTechnologies.PaymentProcessingModule.Common.Models;
using RedSailTechnologies.PaymentProcessingModule.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace RedSailTechnologies.PaymentProcessingModule.Api.Controllers
{
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

        [HttpGet("calculate")]
        public Dictionary<string, Dictionary<DateTime, decimal>> CalculateDailyTotals([FromBody] IEnumerable<Transaction> transactions)
        {
            try
            {
                throw new Exception();
                return _service.CalculateDailyTotals(transactions);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return new Dictionary<string, Dictionary<DateTime, decimal>>();
            }
        }

        [HttpGet("calculate_result")]
        public ActionResult<Dictionary<string, Dictionary<DateTime, decimal>>> CalculateDailyTotalsResult([FromBody] IEnumerable<Transaction> transactions)
        {
            try
            {
                return _service.CalculateDailyTotals(transactions);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return BadRequest("Error occured during calculating daily totals.");
            }
        }
    }
}
