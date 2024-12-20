using FluentValidation;
using PostgresSql.Data;

namespace InsttanttFlujos.Intrastructure.Validators
{
    public class TransactionsValidator : AbstractValidator<Transaction>
    {
        public TransactionsValidator()
        {
            RuleFor(x => x.TraId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.TraProId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.TraDate)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.TraUnits)
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => x.TraUseId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
