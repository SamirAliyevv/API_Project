using ApiTask.core.Entities;
using ApiTask.core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTask.Data.Repositories
{
    public class StudentRepositories : Repository<Student>,IStudentRepository
    {

        public StudentRepositories(StudentDbContext context):base(context)
        {
            
        }

    }
}
