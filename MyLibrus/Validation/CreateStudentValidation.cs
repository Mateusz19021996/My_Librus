using FluentValidation;
using MyLibrus.Entities.DTO;
using MyLibrus.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Validation
{
    public class CreateStudentValidation : AbstractValidator<CreateStudentDTO>
    {
        public CreateStudentValidation(MyLibrusDbContext myLibrusDbContext)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(30)
                .Custom((value, context) =>
                {
                    var isString = !value.Any(char.IsDigit);

                    if (!isString)
                    {
                        context.AddFailure("Name", "Name can't include digits!");
                    }
                });

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(30)
                .Custom((value, context) =>
                {
                    var isString = !value.Any(char.IsDigit);

                    if (!isString)
                    {
                        context.AddFailure("LastName", "Last name can't include digits!");
                    }
                });

            RuleFor(x => x.Age)
                .NotEmpty()
                .Custom((value, context) =>
                {
                    if(value < 7)
                    {
                        context.AddFailure("Age", "Age is too low");
                    }
                });

            RuleFor(x => x.Street)
                .NotEmpty();
                

            //check if student e-mail already exist

            RuleFor(x => x.Mail)
                .Custom((value, context) => 
                {
                    var emailInUse = myLibrusDbContext
                    .Students.Any(x => x.Contact.Mail == value);

                    if (emailInUse)
                    {
                        context.AddFailure("Email", "Email already in use");
                    }
                });
        }
    }
}
