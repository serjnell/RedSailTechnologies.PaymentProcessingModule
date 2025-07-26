using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using RedSailTechnologies.PaymentProcessingModule.Common.Interfaces.Handlers;
using RedSailTechnologies.PaymentProcessingModule.Common.Models;

namespace RedSailTechnologies.PaymentProcessingModule.Api.Controllers
{
    [ApiController]
    [Route("daily_totals")]
    public class DailyTotalsController : ControllerBase
    {
        private readonly IDailyTotalsHandler _handler;

        /// <summary>
        /// Initializes anew instance of <see cref="DailyTotalsController"/>.
        /// </summary>
        /// <param name="handler">The handler.</param>
        public DailyTotalsController(IDailyTotalsHandler handler)
        {
            _handler = handler;
        }

        [HttpGet("calculate")]
        public Dictionary<string, Dictionary<DateTime, decimal>> CalculateDailyTotals([FromBody] IEnumerable<Transaction> transactions)
        {
           return _handler.CalculateDailyTotals(transactions);
        }

        [HttpPost("calculate")]
        public Dictionary<string, Dictionary<DateTime, decimal>> CalculateDailyTotalsAsync([FromQuery] IEnumerable<Transaction> transactions)
        {
            return _handler.CalculateDailyTotals(transactions);
        }

        [HttpGet("test")]
        public string Test()
        {
            return "Succes";
        }
    }
}
