using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Dtos.AdminDtos
{
  public class AppUserRegisterDto // ekleme yaparken bu view modeli kullandık
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string ConfirmPassword { get; set; } //tekrar şifre yani // dorulama yapmak için aynı şifreler olması için

    }
}
