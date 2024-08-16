using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPortalAPI.Application.Features.Commands.Students.CreateStudent
{
    public class CreateStudentCommandValidation : AbstractValidator<CreateStudentCommandRequest>
    {
        public CreateStudentCommandValidation()
        {
            RuleFor(s => s.FirstName).NotEmpty().NotNull().WithMessage("Please fill in the Firts Name field!")
                .MaximumLength(50).MinimumLength(2).WithMessage("Please enter your Firts Name between 2 and 50 characters!");
            RuleFor(s => s.LastName).NotEmpty().NotNull().WithMessage("Please fill in the Last Name field!")
                .MaximumLength(50).MinimumLength(2).WithMessage("Please enter your Last Name between 2 and 50 characters!");
            RuleFor(s => s.Address).NotEmpty().NotNull().WithMessage("Please fill in the Address field!")
                .MaximumLength(50).MinimumLength(5).WithMessage("Please enter your Address between 5 and 50 characters!");
            RuleFor(s => s.Gender).NotEmpty().NotNull().WithMessage("Please fill in the Gender field!")
                .Must(g => g == "Male" || g == "Female").WithMessage("Please enter a valid Gender (Male or Female)!");
            RuleFor(s => s.Email).NotEmpty().NotNull().WithMessage("Please fill in the Email field!")
                .EmailAddress().WithMessage("Please enter a valid Email address!");
            RuleFor(s => s.PhoneNumber).NotEmpty().NotNull().WithMessage("Please fill in the Phone Number field!");
        }
    }
}
