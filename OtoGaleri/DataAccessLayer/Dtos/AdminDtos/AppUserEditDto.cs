using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Dtos.AdminDtos
{
    public class AppUserEditDto // güncellene yaparken kullandık bu viewmodeli
    //burda sisteme otantike olan kişinin bilgilerini bu model üzerinden getirecez bu model veri transfer işlemini görecek yani
    {// bu view model dir bbunun için migration atılmaz yani 
        public string Name { get; set; }
        public string LastName { get; set; }
        public string About { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; } // şifre tekrar için 

    }
}
