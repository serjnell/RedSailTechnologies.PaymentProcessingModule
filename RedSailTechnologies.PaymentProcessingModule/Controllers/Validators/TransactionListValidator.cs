using FluentValidation;
using RedSailTechnologies.PaymentProcessingModule.Common.Models;
using System.Collections.Generic;

namespace RedSailTechnologies.PaymentProcessingModule.Api.Controllers.Validators
{
    public class TransactionListValidator : AbstractValidator<List<Transaction>>
    {
        public TransactionListValidator()
        {
            RuleForEach(x => x).SetValidator(new TransactionValidator());
        }
    }
}
