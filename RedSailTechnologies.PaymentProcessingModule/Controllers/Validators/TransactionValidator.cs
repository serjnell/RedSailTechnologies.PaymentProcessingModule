using FluentValidation;
using RedSailTechnologies.PaymentProcessingModule.Common.Enums;
using RedSailTechnologies.PaymentProcessingModule.Common.Models;
using System;

namespace RedSailTechnologies.PaymentProcessingModule.Api.Controllers.Validators
{
    public class TransactionValidator : AbstractValidator<Transaction>
    {
        public TransactionValidator()
        {
            RuleFor(x => x.Amount).GreaterThan(0)
                .WithMessage("Amount can't be less than zero.");

            RuleFor(x => x.Amount).LessThanOrEqualTo(decimal.MaxValue)
                .WithMessage($"Amount can't be greater than {decimal.MaxValue}.");

            RuleFor(x => x.Currency).Must(x => Enum.IsDefined(typeof(Currencies), x))
                .WithMessage("Currency is not supported by payment module.");
            
            RuleFor(x => x.Timestamp).GreaterThan(DateTime.MinValue)
                .WithMessage($"Date can't be less than {DateTime.MinValue}.");

            RuleFor(x => x.Timestamp).LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("Future dates are not supported.");
        }
    }
}
