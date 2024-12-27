using FluentValidation;
using Prueba.Core.DTOs;

namespace InsttanttFlujos.Intrastructure.Validators
{
    public class UserCreacionValidatorDTO : AbstractValidator<UserCreacionDTO>
    {
        public UserCreacionValidatorDTO()
        {
            RuleFor(x => x.UseId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.UseName)
                .NotNull()
                .NotEmpty()
                .Length(1, 100);

            RuleFor(x => x.UseDocument)
                .NotNull()
                .NotEmpty()
                .Length(1, 50);
        }
    }


}
