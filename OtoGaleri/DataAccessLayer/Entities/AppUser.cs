using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Entities
{
    public class AppUser:IdentityUser<int> //// IdentityUser: veritabanındaki  aspnetusers tablosuyla ilişkiye koyacaz ve ordaki tabloya eklmek istediğimniz verileri ekleyecez ;IdentityUser =aspnetusers tablosu gibi düşün
    //<int> bunu toblodaki id primary si string ti bunu int ecevirdik bu yuzden ve gerekli diğer tablolarıda çevir role me filan daha sağlıklı
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string About { get; set; }
        public string ImageUrl { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public int ConfirmCode { get; set; }//onay kodu,mail doğrulama işlemi için kullanılacak ,migration olduğunda migration da nullable yi true yaptık ayrıntı

        public List<Carousel> Carousels { get; set; } 
        public List<Brand> Brands { get; set; } 
        public List<Service> Services { get; set; } 
        public List<About> Abouts { get; set; } 
        public List<Team> Teams { get; set; } 
        public List<Car> Cars { get; set; } 
        public List<CarKategori> CarKategoris { get; set; } 
        public List<CarDetay> CarDetays { get; set; } 
   
        public List<ContactCity> ContactCities { get; set; }
 


    }
}
