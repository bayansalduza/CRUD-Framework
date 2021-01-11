using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dto
{
    public class ProjectDto
    {
        //Databasede olan project tablosunun "Data Transfer Object" classı.
        public int Id { get; set; }
        public string ProjectName { get; set; }
    }
}
