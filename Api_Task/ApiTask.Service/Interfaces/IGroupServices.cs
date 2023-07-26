using ApiTask.Service.Dtos.Common;
using ApiTask.Service.Dtos.GroupDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTask.Service.Interfaces
{
    public  interface IGroupServices
    {

        CreatResultDto Create(GroupCreatDto dto);

        void Update(int id, GroupEditDto dto);

        GroupGetDto GetById(int id);

        List<GroupGetAllDto> GetAll();

        void Delete(int id);

    }
}
