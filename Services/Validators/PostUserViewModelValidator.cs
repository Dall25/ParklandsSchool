using FluentValidation;
using Models.ViewModels;


namespace Services.Validators
{
    public class PostUserViewModelValidator : AbstractValidator<PostUserViewModel>
    {
        public PostUserViewModelValidator()
        {
            RuleFor(viewModel => viewModel.User).SetValidator(new UserValidator());
        }
    }
}

