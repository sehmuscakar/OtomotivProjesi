namespace PresentationLayer.Areas.Admin.Models
{
    public class LoginViewModel
    // burda dto olarak ta bunu yapabilirdik, ama viewmodel olarak yaptık loginden hangi entityler üzerinden giriş yapılacaksa onları tanımlyoruz ve atamalrını yapacaz 
    {
        
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
