using AcSight.Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcSight.Core.Validators
{
    public class UserValidator : AbstractValidator<UserLoginModel>
    {
        public UserValidator()
        {
            RuleFor(r => r.UserName).NotEmpty()
                .WithMessage("Kullanıcı Adı boş olamaz");
            RuleFor(r => r.Password).NotEmpty().MinimumLength(4)
                .WithMessage("Parola en az 4 haneli olmalıdır.");
        }
    }
}
