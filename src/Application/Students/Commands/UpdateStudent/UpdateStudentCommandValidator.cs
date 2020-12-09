using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector.Application.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
    {
        public UpdateStudentCommandValidator()
        {
            RuleFor(v => v.FirstName)
               .MaximumLength(50)
               .NotEmpty();

            RuleFor(v => v.MiddleName)
              .MaximumLength(50);

            RuleFor(v => v.LastName)
              .MaximumLength(50)
              .NotEmpty();

            RuleFor(v => v.Email)
              .NotEmpty();
        }
    }
}
