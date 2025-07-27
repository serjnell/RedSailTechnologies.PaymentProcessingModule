using FluentAssertions;
using RedSailTechnologies.PaymentProcessingModule.Common.Models;
using RedSailTechnologies.PaymentProcessingModule.Services.Services;
using AutoFixture;

namespace RedSailTechnologies.PaymentProcessingModule.Tests.UnitTests
{
    [TestClass]
    public class DailyTotalsServiceTest
    {
        private const string UsdCurrency = "USD";
        private const string EurCurrency = "EUR";

        private DateTime TestDate = new DateTime(2025, 7, 27);

        private DailyTotalsService _sut;
        private readonly Fixture _fixture = new Fixture();

        [TestInitialize]
        public void Setup()
        {
            _sut = new DailyTotalsService();
        }

        [TestMethod]
        public void CalculateDailyTotals_Test()
        {
            var transactions = _fixture.Create<List<Transaction>>();

            var result = _sut.CalculateDailyTotals(transactions);

            result.Should().NotBeNull();
            result.Count.Should().BeGreaterThan(1);
        }
    }
}
