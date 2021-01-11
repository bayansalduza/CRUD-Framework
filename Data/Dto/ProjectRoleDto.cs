using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dto
{
    public class ProjectRoleDto
    {
        //Database tablolarını Join yaparken tek bir "Data Object Transfer" classında tutmamız için oluşturduğumuz class.
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public string ProjectName { get; set; }
        public string UserName { get; set; }
    }
}
