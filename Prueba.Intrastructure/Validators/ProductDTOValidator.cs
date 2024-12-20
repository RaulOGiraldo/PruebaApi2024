using FluentValidation;
using Prueba.Core.DTOs;

namespace InsttanttFlujos.Intrastructure.Validators
{
    public class ProductDTOValidator : AbstractValidator<ProductDTO>
    {
        public ProductDTOValidator()
        {

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
