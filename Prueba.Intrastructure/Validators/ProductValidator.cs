using FluentValidation;
using PostgresSql.Data;

namespace InsttanttFlujos.Intrastructure.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.ProName)
                .NotNull()
                .NotEmpty()
                .Length(1, 100);

            RuleFor(x => x.ProStock)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
