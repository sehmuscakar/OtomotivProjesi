namespace DataAccessLayer.Entities
{
    public class Carousel:BaseEntity // bu alan header ın altındaki görsel ve yazılar dır carousel:slayder alanının yeri yani 
    {
        public string ImageUrl { get; set; }
        public string Title1 { get; set; }
        public string Title2 { get; set; }
    }
}
