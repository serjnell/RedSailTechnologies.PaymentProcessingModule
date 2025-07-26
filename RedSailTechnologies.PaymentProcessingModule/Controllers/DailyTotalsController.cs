using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Transactions;
using System;

namespace RedSailTechnologies.PaymentProcessingModule.Api.Controllers
{
    [ApiController]
    [Route("daily_totals")]
    public class DailyTotalsController : ControllerBase
    {
        [HttpGet("calculate")]
        public Dictionary<string, Dictionary<DateTime, decimal>> CalculateDailyTotals(IEnumerable<Transaction> transactions)
        {
            throw new NotImplementedException();
        }
    }
}
