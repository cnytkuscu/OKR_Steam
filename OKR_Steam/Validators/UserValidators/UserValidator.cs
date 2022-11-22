using FluentValidation;
using OKR_Steam.Models.RequestModels;

namespace OKR_Steam.Validators.UserValidators
{
    public class UserValidator : AbstractValidator<SteamProfileRequestModel>
    {
        public UserValidator()
        {
            RuleFor(x => x.Username).NotEmpty().When(x => !String.IsNullOrEmpty(x.ProfileURL) && !String.IsNullOrEmpty(x.TradeURL)).WithMessage("Username Parametresi boş olamaz.");
            RuleFor(x => x.Username).Must(x => x.Length <= 20).When(x => !String.IsNullOrEmpty(x.Username) && String.IsNullOrEmpty(x.TradeURL) && String.IsNullOrEmpty(x.ProfileURL)).WithMessage("Username parametresi 20 karakterden uzun olamaz !");

            
            RuleFor(x => x.ProfileURL).NotEmpty().When(x => !String.IsNullOrEmpty(x.Username) && !String.IsNullOrEmpty(x.TradeURL)).WithMessage("ProfileURL Parametresi boş olamaz.");
            RuleFor(x => x.ProfileURL).Must(x => x.Length <= 30).When(x => !String.IsNullOrEmpty(x.ProfileURL) && !String.IsNullOrEmpty(x.TradeURL) && String.IsNullOrEmpty(x.Username)).WithMessage("ProfileURL parametresi 30 karakterden uzun olamaz !");
           

            RuleFor(x => x.TradeURL).NotEmpty().When(x => !String.IsNullOrEmpty(x.Username) && !String.IsNullOrEmpty(x.ProfileURL)).WithMessage("TradeURL Parametresi boş olamaz.");
            RuleFor(x => x.TradeURL).Must(x => x.Length <= 50).When(x => !String.IsNullOrEmpty(x.TradeURL) && !String.IsNullOrEmpty(x.ProfileURL) && String.IsNullOrEmpty(x.Username)).WithMessage("TradeURL parametresi 50 karakterden uzun olamaz !");



        }
    }
}

