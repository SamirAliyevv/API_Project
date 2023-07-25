using ApiTask.core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTask.Data.Configurations
{
    internal  class Studentconfiguration:IEntityTypeConfiguration<Student>
    {

        public void Configure(EntityTypeBuilder<Student> builder)
        {


            builder.Property(x=>x.FullName).IsRequired().HasMaxLength(70);
        }

    }
}
