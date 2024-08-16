using FluentValidation;
using StudentPortalAPI.Application.ViewModels.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPortalAPI.Application.Validators.Courses
{
    public class CreateCourseValidator : AbstractValidator<VM_Create_Course>
    {
        public CreateCourseValidator()
        {
            RuleFor(c => c.CourseName).NotEmpty().NotNull().WithMessage("Please fill in the Name field!")
                .MaximumLength(50).MinimumLength(5).WithMessage("Please enter Course Name between 5 and 50 characters!");
            RuleFor(c => c.Credits).NotNull().WithMessage("Please fill in the Credit field!")
                .Must(credit => credit >= 0 && credit <= 10).WithMessage("Credit must be between 0 and 10");
        }
    }
}
