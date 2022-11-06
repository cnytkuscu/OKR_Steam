using FluentValidation;
using OKR_Steam.Models.RequestModels;

namespace OKR_Steam.Validators.UserValidators
{
    public class UserValidator :AbstractValidator<SteamProfileRequestModel>
    {
        public UserValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Username Parametresi boş olamaz.");
               

        }
    }
}
