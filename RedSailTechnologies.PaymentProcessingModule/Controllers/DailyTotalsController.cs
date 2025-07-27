using Microsoft.AspNetCore.Mvc;
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

        /// <summary>
        /// Initializes a new instance of a <see cref="DailyTotalsController"/>.
        /// </summary>
        /// <param name="service">The <see cref="IDailyTotalsService"/> service.</param>
        public DailyTotalsController(IDailyTotalsService service)
        {
            _service = service;
        }

        [HttpGet("calculate")]
        public Dictionary<string, Dictionary<DateTime, decimal>> CalculateDailyTotals([FromBody] IEnumerable<Transaction> transactions)
        {
           return _service.CalculateDailyTotals(transactions);
        }

        //[HttpGet("calculates")]
        //public ActionResult<Dictionary<string, Dictionary<DateTime, decimal>>> CalculateDailyTotals2([FromBody] IEnumerable<Transaction> transactions)
        //{
        //    return _handler.CalculateDailyTotals(transactions);
        //}

        [HttpGet("test")]
        public string Test()
        {
            return "Succes";
        }
    }
}
