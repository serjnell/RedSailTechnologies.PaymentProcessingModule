using RedSailTechnologies.PaymentProcessingModule.Common.Models;

namespace RedSailTechnologies.PaymentProcessingModule.Common.Interfaces.Handlers
{
    /// <summary>
    /// The daily totals handler.
    /// </summary>
    public interface IDailyTotalsHandler
    {
        /// <summary>
        /// Calculates daily totals.
        /// </summary>
        /// <param name="transactions">The transactions.</param>
        /// <returns>Daily totals grouped by currency.</returns>
        Dictionary<string, Dictionary<DateTime, decimal>> CalculateDailyTotals(IEnumerable<Transaction> transactions);
    }
}
