using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTask.Service.Dtos.StudentDtos
{
    public class StudentGetDto
    {

        public string  FullName { get; set; }

        public decimal  Point { get; set; }

          
        public StudentGetDtoGroupIn Group { get; set; } 
     
    }


    public class StudentGetDtoGroupIn
    {

        public int Id { get; set; } 

        public string  GroupNo { get; set; }
    }
}
