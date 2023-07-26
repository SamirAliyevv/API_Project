using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ApiTask.Service.Dtos.GroupDtos
{
    public  class GroupCreatDto
    {
        public string   GroupNo  { get; set; }

    }
    public class GroupCreatDtoValidator : AbstractValidator<GroupCreatDto>
    {

        public GroupCreatDtoValidator()
        {
            RuleFor(x => x.GroupNo).NotEmpty().MaximumLength(6);
        }

    }
}
