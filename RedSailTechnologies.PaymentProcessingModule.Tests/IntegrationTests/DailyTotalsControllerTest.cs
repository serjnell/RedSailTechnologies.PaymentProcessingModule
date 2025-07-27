using FluentAssertions;
using Microsoft.Extensions.Logging;
using RedSailTechnologies.PaymentProcessingModule.Api.Controllers;
using RedSailTechnologies.PaymentProcessingModule.Api.Controllers.Validators;
using RedSailTechnologies.PaymentProcessingModule.Common.Models;
using RedSailTechnologies.PaymentProcessingModule.Services.Services;

namespace RedSailTechnologies.PaymentProcessingModule.Tests.IntegrationTests
{
    [TestClass]
    public class DailyTotalsControllerTest
    {
        private const string UsdCurrency = "USD";
        private const string EurCurrency = "EUR";

        private DateTime TestDate = new DateTime(2025, 7, 28);

        private DailyTotalsController _sut;

        [TestInitialize]
        public void Setup()
        {
            using var loggerFactory = LoggerFactory.Create(loggingBuilder => loggingBuilder
                                                   .SetMinimumLevel(LogLevel.Error)
                                                   .AddConsole());

            var logger = loggerFactory.CreateLogger<DailyTotalsController>();
            var dailyTotalsService = new DailyTotalsService();
            
            _sut = new DailyTotalsController(logger, dailyTotalsService);
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

        [TestMethod]
        public async Task CalculateDailyTotalsAsync_Succes()
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
            var result = await _sut.CalculateDailyTotalsAsync(transactions);

            //Assert
            result.Value.Should().BeEquivalentTo(expectedResult);
        }

        [TestMethod]
        public void CalculateDailyTotals_Fail()
        {
            //Arrange
            var validator = new TransactionListValidator();
            var transactions = new List<Transaction>()
            {
                new Transaction() {Amount = -15, Currency = "1", Timestamp = TestDate},
                new Transaction() {Amount = -5, Currency = "X", Timestamp = TestDate},
                new Transaction() {Amount = 20, Currency = "X", Timestamp = TestDate.AddDays(-1)},
                new Transaction() {Amount = 20, Currency = "Y", Timestamp = TestDate.AddDays(-1)},
            };

            //Act
            var result = validator.Validate(transactions);

            //Assert
            Assert.IsFalse(result.IsValid);
        }
    }
}