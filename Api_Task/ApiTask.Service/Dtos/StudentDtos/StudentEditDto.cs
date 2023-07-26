using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTask.Service.Dtos.StudentDtos
{
    public class StudentEditDto
    {

        public int GroupId { get; set; }

        public string FullName { get; set; }

        public decimal Point { get; set; }
    }



    public class StudentEditDtoValidator : AbstractValidator<StudentEditDto>
    {


        public StudentEditDtoValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().MaximumLength(70);
            RuleFor(x=>x.Point).NotEmpty().GreaterThanOrEqualTo(0);

        }


    }
}
