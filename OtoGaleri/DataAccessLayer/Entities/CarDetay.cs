namespace DataAccessLayer.Entities
{
    public class CarDetay:BaseEntity
    {
        public string ImageUrl { get; set; }
        public int Year { get; set; }
        public int Km { get; set; }
        public int Price { get; set; }
        public DateTime AdvertTime  { get; set; } //ilan zamanı

        public string Description { get; set; }

        public List<Car> Cars { get; set; }
 


    }
}
