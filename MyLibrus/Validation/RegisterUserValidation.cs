using FluentValidation;
using MyLibrus.Entities.DTO.CreateDTO;
using MyLibrus.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Validation
{
    public class RegisterUserValidation : AbstractValidator<CreateUserDTO>
    {
        public RegisterUserValidation(MyLibrusDbContext myLibrusDbContext)
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(10);

            RuleFor(x => x.Password)
                .MinimumLength(10);

            RuleFor(x => x.Mail)
                .NotEmpty()
                .EmailAddress()
                // here we can write our own logic of validation; value is value provided by client in this case
                // value - wartosc z pola email
                // context - kontekst walidacji
                .Custom((value, context) =>
                {
                    var isEmailValidate = myLibrusDbContext
                    .Users
                    .Any(u => u.Mail == value);

                    if (isEmailValidate)
                    {
                        context.AddFailure("Email", "Email is already in use");
                    }
                });

            

        }
    }
}
