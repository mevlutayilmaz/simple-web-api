using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPortalAPI.Application.Features.Commands.Students.UpdateStudent
{
    public class UpdateStudentCommandValidatior : AbstractValidator<UpdateStudentCommandRequest>
    {
        public UpdateStudentCommandValidatior()
        {
            RuleFor(s => s.Email).NotEmpty().NotNull().WithMessage("Please fill in the Email field!")
                .EmailAddress().WithMessage("Please enter a valid Email address!");
            RuleFor(s => s.Address).NotEmpty().NotNull().WithMessage("Please fill in the Address field!")
                .MaximumLength(50).MinimumLength(5).WithMessage("Please enter your Firts Name between 5 and 50 characters!");
            RuleFor(s => s.PhoneNumber).NotEmpty().NotNull().WithMessage("Please fill in the Phone Number field!");
        }
    }
}
