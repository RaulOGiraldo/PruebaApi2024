using FluentValidation;
using Prueba.Core.DTOs;

namespace InsttanttFlujos.Intrastructure.Validators
{
    public class UserDTOValidator : AbstractValidator<UserDTO>
    {
        public UserDTOValidator()
        {
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
