using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTask.Service.Dtos.GroupDtos
{
    public  class GroupEditDto
    {

        public string GroupNo { get; set; } 

    }


    public class GroupEditDtoValidator : AbstractValidator<GroupEditDto>
    {


        public GroupEditDtoValidator()
        {
            RuleFor(x => x.GroupNo).NotEmpty().MaximumLength(6);
        }
    }
}
