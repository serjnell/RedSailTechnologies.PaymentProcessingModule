using RedSailTechnologies.PaymentProcessingModule.Common.Interfaces.Handlers;
using RedSailTechnologies.PaymentProcessingModule.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RedSailTechnologies.PaymentProcessingModule.Api.Controllers.DailyTotals
{
    public class DailyTotalsHandler: IDailyTotalsHandler
    {
        ///<inheritdoc/>
        public Dictionary<string, Dictionary<DateTime, decimal>> CalculateDailyTotals(IEnumerable<Transaction> transactions)
        {
            var result = transactions.GroupBy(x => x.Currency)
                                     .ToDictionary(k => k.Key, v => v.GroupBy(x => x.Timestamp.Date)
                                                                     .ToDictionary(k => k.Key, v => v.Sum(x => x.Amount)));
            return result;
        }
    }
}
