using FluentValidation;
using PostgresSql.Data;

namespace InsttanttFlujos.Intrastructure.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
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
