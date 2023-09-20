using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.Context
{
    // biz ıdentity imiz büylece özeleştirdik appuser ,approle ve int olarak genel primary olarak stringten int e cevirdik user ile ilgili biz özel olarak hangi tabloları yapmışsak buraya da eklememiz lazım 
    //,int> bu int primary i leri strigten int e cevirecek genel olarak diğer paremeetrelede özeleştirilmiş olanlar primary meselesi özeleştirilmiş tablolarda da yapıldı yapılmış olamsı lazım dikkat et
    // identityde özeleştirilmiş olan sınıflarımızı dbset olarak eklememize gerek yok migration ve update yapman yeterli ama ilgili migrationları veya genel migration kalsörünü ve db yi silip baştan yaparsan daha sağlıklı olur 

    // sonra db yi katrol et özeleşrtirilmiş tabloları diyagram oluştur ilşkilerde bi sıkıntı yoksa sıkıntı yoktur devam et.

    // Microsoft.AspNetCore.Identity.EntityFrameworkCore // identity ekleyebilmen için bu kütüphane mutlaka ekli olamsı lazım ilgili yere
  //  Microsoft.Extensions.Identity.Core bunun da ekli olması lazım
    public class ProjeContext : IdentityDbContext<AppUser,AppRole,int> //DbContext
    {
        public DbSet<Carousel> Carousels { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarKategori> CarKategoris { get; set; }
        public DbSet<CarDetay> CarDetays { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactCity> ContactCities { get; set; }
       
        public DbSet<CarRequestForm> CarRequestForms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)// overide on yaz gelir
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-PBFD0LU;  database=OtoGalleriProje; integrated security=true; TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder builder)//fluent api ile ilgili ,bunu yapmazsan appuser da kim ekledi kısmında ıd yerine name gelmez bunu yapman lazım
        {

            builder.Entity<Carousel>(entity =>
            {

                entity.HasOne(x => x.AppUser).WithMany(x => x.Carousels).HasForeignKey(x => x.AppUserId);
            });


            builder.Entity<Brand>(entity =>
            {

                entity.HasOne(x => x.AppUser).WithMany(x => x.Brands).HasForeignKey(x => x.AppUserId);
            });

            builder.Entity<Service>(entity =>
            {

                entity.HasOne(x => x.AppUser).WithMany(x => x.Services).HasForeignKey(x => x.AppUserId);
            });
            builder.Entity<About>(entity =>
            {

                entity.HasOne(x => x.AppUser).WithMany(x => x.Abouts).HasForeignKey(x => x.AppUserId);
            });

            builder.Entity<Team>(entity =>
            {

                entity.HasOne(x => x.AppUser).WithMany(x => x.Teams).HasForeignKey(x => x.AppUserId);
            });

            builder.Entity<Car>(entity =>
            {

                entity.HasOne(x => x.AppUser).WithMany(x => x.Cars).HasForeignKey(x => x.AppUserId);
                //entity.HasOne(x => x.CarGallery).WithMany(x => x.Cars).HasForeignKey(x => x.CarGalleryId);
                entity.HasOne(x => x.CarDetay).WithMany(x => x.Cars).HasForeignKey(x => x.CarDetayId);
                entity.HasOne(x => x.CarKategori).WithMany(x => x.Cars).HasForeignKey(x => x.CarKategoriId);
          
            });

            builder.Entity<CarDetay>(entity =>
            {
              
                entity.HasOne(x => x.AppUser).WithMany(x => x.CarDetays).HasForeignKey(x => x.AppUserId);
               
            });         

            builder.Entity<ContactCity>(entity =>
            {

                entity.HasOne(x => x.AppUser).WithMany(x => x.ContactCities).HasForeignKey(x => x.AppUserId);

            });
          
            //builder.Entity<CarGaleri>(entity =>
            //{


            //    entity.HasOne(x => x.AppUser).WithMany(x => x.CarGaleris).HasForeignKey(x => x.AppUserId);
            //    entity.HasOne(x => x.CarDetay).WithMany(x => x.CarGaleris).HasForeignKey(x => x.CarDetayFotoId);
            //});


            base.OnModelCreating(builder);
        }
    }
}
