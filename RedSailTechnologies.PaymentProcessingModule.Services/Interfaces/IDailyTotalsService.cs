using RedSailTechnologies.PaymentProcessingModule.Common.Models;

namespace RedSailTechnologies.PaymentProcessingModule.Services.Interfaces
{
    /// <summary>
    /// The daily totals service.
    /// </summary>
    public interface IDailyTotalsService
    {
        /// <summary>
        /// Calculates daily totals.
        /// </summary>
        /// <param name="transactions">The transactions.</param>
        /// <returns>Daily totals grouped by currency.</returns>
        Dictionary<string, Dictionary<DateTime, decimal>> CalculateDailyTotals(IEnumerable<Transaction> transactions);
    }
}
