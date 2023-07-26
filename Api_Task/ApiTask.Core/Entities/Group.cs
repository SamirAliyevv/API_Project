using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTask.core.Entities
{
    public class Group
    {

        public int Id { get; set; }
        public string GroupNo { get; set; } 
        List<Student> Students { get; set;}
    }
}
