using RedSailTechnologies.PaymentProcessingModule.Common.Models;
using RedSailTechnologies.PaymentProcessingModule.Services.Interfaces;

namespace RedSailTechnologies.PaymentProcessingModule.Services.Services
{
    public class DailyTotalsService : IDailyTotalsService
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
