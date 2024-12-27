using FluentValidation;
using Prueba.Core.DTOs;

namespace InsttanttFlujos.Intrastructure.Validators
{
    public class ProductCreacionDTOValidator : AbstractValidator<ProductCreacionDTO>
    {
        public ProductCreacionDTOValidator()
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
