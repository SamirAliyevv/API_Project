using ApiTask.Service.Dtos.Common;
using ApiTask.Service.Dtos.StudentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTask.Service.Interfaces
{
    public interface IStudentServices
    {
        CreatResultDto Create(StudentCreatDto dto);

        void Edit(int id, StudentEditDto dto);

        StudentGetDto GetById(int id);

        List<StudentGetAllDto> GetAll();

        void Delete(int id);    

    }
}
