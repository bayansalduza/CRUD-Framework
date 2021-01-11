using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dto
{
    public class UserDto
    {
        //Kullanıcının bilgilerini görüntülemek ve kullanmak amacı ile oluşturulan "Data Transafer Object" classı.
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
    }
}
