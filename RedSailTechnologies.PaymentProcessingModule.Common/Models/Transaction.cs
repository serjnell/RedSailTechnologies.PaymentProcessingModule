namespace RedSailTechnologies.PaymentProcessingModule.Common.Models
{
    /// <summary>
    /// The transaction.
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// The amount.
        /// </summary>
        public decimal Amount { get; set; } 
        
        /// <summary>
        /// The currency.
        /// </summary>
        public string Currency { get; set; }//(e.g., "USD", "EUR")
        
        /// <summary>
        /// The timestamp.
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}
                                                                                                                     