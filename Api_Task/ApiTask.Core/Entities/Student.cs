using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTask.core.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public int GroupId { get; set; }

        public Group Group { get; set; }

        public string FullName { get; set; }

        public decimal Point { get; set; }
        
    }
}
