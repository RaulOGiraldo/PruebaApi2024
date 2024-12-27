using FluentValidation;
using Prueba.Core.DTOs;

namespace InsttanttFlujos.Intrastructure.Validators
{
    public class RoleValidatorDTO : AbstractValidator<RolDTO>
    {
        public RoleValidatorDTO()
        {
            RuleFor(x => x.RolId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.RolName)
                .NotNull()
                .NotEmpty()
                .Length(1, 100);

        }
    }
}
