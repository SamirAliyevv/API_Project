using ApiTask.core.Entities;
using ApiTask.core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ApiTask.Data.Repositories
{
    public class GroupRepositories : Repository<Group>, IGroupRepository
    {

        public GroupRepositories(StudentDbContext context) : base(context)
        {

        }

    }
}
