

using FluentValidation;
using Models.Entities;

namespace Services.Validators
{

    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.FirstName).NotNull().NotEmpty().WithMessage("Please enter a first name");
            RuleFor(user => user.FirstName).MaximumLength(50).MinimumLength(2).WithMessage("Please enter a first name between 2 and 50 characters"); ;
            RuleFor(user => user.LastName).NotNull().NotEmpty().WithMessage("Please enter a last name");
            RuleFor(user => user.LastName).MaximumLength(50).MinimumLength(2).WithMessage("Please enter a surname between 2 and 100 characters");
            RuleFor(user => user.UserTypeId).NotNull().NotEmpty().WithMessage("Please enter a user type");

        }
    }
}