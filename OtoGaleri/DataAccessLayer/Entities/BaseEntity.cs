using CoreLayer.Entities;

namespace DataAccessLayer.Entities
{
    public class BaseEntity:IEntity // IEntityden miras alma sebei direk veritabanında varlıklara erişilmesi dir gibi bi anlamı vardı sanki 
    {
        public int Id { get; set; }

   
        public DateTime? LastUpdatedAt { get; set; }
        public int RowOrder { get; set; }
        public int? AppUserId { get; set; } // forein key diir bu appuserın 
        public virtual AppUser AppUser { get; set; }  // tekli olanın forein keyi olur oda burda işte Createdby userın forenkeyi dir

    }
}
