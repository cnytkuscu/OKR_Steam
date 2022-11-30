using FluentValidation;
using OKR_Steam.Models.DBModels.DBRequestModels;
using OKR_Steam.Models.RequestModels;

namespace OKR_Steam.Validators.UserValidators
{
    public class UpdateSteamProfileDataValidator : AbstractValidator<UpdateSteamProfileData>
    {
        public UpdateSteamProfileDataValidator()
        {
            RuleFor(x => x.SteamId)
                    .NotNull().WithMessage("SteamId Null olamaz.")
                    .NotEmpty().WithMessage("SteamId boş Guid olamaz.");

            RuleFor(x => x.Username).NotEmpty().When(x => !String.IsNullOrEmpty(x.Username)).WithMessage("Username Parametresi boş olamaz.")
                    .Must(x => x.Length <= 20).When(x => !String.IsNullOrEmpty(x.Username) && String.IsNullOrEmpty(x.TradeURL) && String.IsNullOrEmpty(x.ProfileURL)).WithMessage("Username parametresi 20 karakterden uzun olamaz !");

            RuleFor(x => x.ProfileState).NotEmpty().WithMessage("ProfileState boş olamaz.");
                    
        }
    }
}
