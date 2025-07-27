using FluentAssertions;
using RedSailTechnologies.PaymentProcessingModule.Common.Models;
using RedSailTechnologies.PaymentProcessingModule.Services.Services;

namespace RedSailTechnologies.PaymentProcessingModule.Tests.IntegrationTests
{
    [TestClass]
    public class DailyTotalsServiceTest
    {
        private const string UsdCurrency = "USD";
        private const string EurCurrency = "EUR";

        private DateTime TestDate = new DateTime(2025, 7, 28);

        private DailyTotalsService _sut;

        [TestInitialize]
        public void Setup()
        {
            _sut = new DailyTotalsService();
        }

        [TestMethod]
        public void CalculateDailyTotals_Succes()
        {
            //Arrange
            var transactions = new List<Transaction>()
            {
                new Transaction() {Amount = 15, Currency = UsdCurrency, Timestamp = TestDate},
                new Transaction() {Amount = 15, Currency = UsdCurrency, Timestamp = TestDate},
                new Transaction() {Amount = 20, Currency = UsdCurrency, Timestamp = TestDate.AddDays(-1)},
                new Transaction() {Amount = 20, Currency = UsdCurrency, Timestamp = TestDate.AddDays(-1)},

                new Transaction() {Amount = 15, Currency = EurCurrency, Timestamp = TestDate},
                new Transaction() {Amount = 15, Currency = EurCurrency, Timestamp = TestDate},
                new Transaction() {Amount = 20, Currency = EurCurrency, Timestamp = TestDate.AddDays(-1)},
                new Transaction() {Amount = 20, Currency = EurCurrency, Timestamp = TestDate.AddDays(-1)},
            };


            var expectedResult = new Dictionary<string, Dictionary<DateTime, Decimal>>()
            {
                {"USD", new Dictionary<DateTime, decimal>()
                    {
                        {TestDate, 30},
                        {TestDate.AddDays(-1), 40},
                    }
                },
                {"EUR", new Dictionary<DateTime, decimal>()
                {
                    {TestDate, 30},
                    {TestDate.AddDays(-1), 40},
                }
}
            };

            //Act
            var result = _sut.CalculateDailyTotals(transactions);

            //Assert
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}