using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
namespace OtoGaleriPresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
   [AllowAnonymous] // 
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager; // bu sınıf ıdentity içinde bulunan hazır bir sınıf 

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()// kayıtlı olan kullanıları listeleyecek
        {
            var listele = _userManager.Users.ToList();
            return View(listele);
        }


        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(AppUserRegisterDto appUserRegisterDto) //AppUserRegisterDto bu modeli kullanma amacımız sadece gerekli propertyleri kullanmak için 
        {
            if (ModelState.IsValid)
            {
                Random random = new Random();
                int code;
                code = random.Next(100000, 1000000);//1 .ci değer dahil 2.ci değer dahildeğil
                AppUser appUser = new AppUser() // atamalarımızı yaptık
                {
                    Name = appUserRegisterDto.Name,
                    LastName= appUserRegisterDto.LastName,
                    Email= appUserRegisterDto.Email,
                    UserName = appUserRegisterDto.UserName,
                    ImageUrl = "",
                    Phone="",
                    Adress="",
                    About="",
                    // burda entityin kendi tablolarındaki propertylerinde bazıları nul gecçe veya geçmeme onlara dikat et senin yazdığın validasyonlarınla ilgisi yok onları kontrol etmen lazım 
                    ConfirmCode = code,
                };

                var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);//eklemeleri yapacak ilgili olanları ve result değişkenine atama yapacak
                if (result.Succeeded)
                {
                    // bu kodların hepsi scakar542@gmail.com mailinden örnek sehmuscakar617@gmail.com a mail yani onay kodu gönderdik ,scakar542@gmail.com bunun mutlaka iki adımlı doğrulaması açık olması lazım 
                    MimeMessage mimeMessage = new MimeMessage();// minekit kütüphanesi eklemen lazım bunun için maile doğrulama yapmak için 

                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Şehmus", "scakar542@gmail.com");//kimden geleceği isim ve adres
                    MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);//kime gideği isim ve adres

                    mimeMessage.From.Add(mailboxAddressFrom);//kimden gelecek ekle

                    mimeMessage.To.Add(mailboxAddressTo);//kime gidecek ekle

                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = "Kayıt işlemini gerçekleştirmek için onay kodunuz" + code;
                    mimeMessage.Body = bodyBuilder.ToMessageBody();   //mesaja ekle body kısmına 

                    mimeMessage.Subject = "Çakar Oto Galeri Onay Kodu";//konu kısmı

                    SmtpClient client = new SmtpClient();// mail trnsfer nesne örneği protokol
                    client.Connect("smtp.gmail.com", 587, false);//prokol gereklikleri bağlantı kurma ,burda bağlatı güvenliğine false dedik çünkü ConfirmMailController da true işlemi yapacaz emailconfirmed

                    client.Authenticate("scakar542@gmail.com", "xcej aamu fcku qptb");//mail ve mailde oluşturduğun güvenlik kodu
                    client.Send(mimeMessage);//gönder
                    client.Disconnect(true);//gövenli çıkış yap 
                    //bu işlemi yapman için iki adımlı doğrulamyı mail de açman lazım

                    TempData["Mail"] = appUserRegisterDto.Email;// bu ksıım taşımkla  ilgili bu tempdata nın içine sakladık maili 

                    return RedirectToAction("ConfirmMail", "Login"); //ekleme olduktan sonra mail doğrulama controlerına yönlendirecek
                }

                else
                {
                    foreach (var item in result.Errors) //model içindeki hata mesajlarını bize dçndürecek bu , senin tanımladığın validasyonlar çalışıyor onlar bunlar ayrı sistemsel hatalar çoğunluıkla ingilizce hatalar yani çok önemli bu ksıım 
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MyAccount() // profil bilgilerini getirme işlemi yapacaz 
        {

            var values = await _userManager.FindByNameAsync(User.Identity.Name); // burda sisteme login olan otantike olan kişin bilgilerini name göre bulacak ve getirecek yani username göre diyeebiliriz
            AppUserEditDto appUserEditDto = new AppUserEditDto();// bu bi nevi view model olarak hareket edecek
            appUserEditDto.Name = values.Name;
            appUserEditDto.LastName = values.LastName;
            appUserEditDto.Phone = values.Phone;
            appUserEditDto.Email = values.Email;
            appUserEditDto.About = values.About;
            appUserEditDto.ImageUrl = appUserEditDto.ImageUrl;
            appUserEditDto.Adress = values.Adress;
            appUserEditDto.ImageUrl = values.ImageUrl;
            return View(appUserEditDto);

        }

        [HttpPost]
        public async Task<IActionResult> MyAccount(AppUserEditDto appUserEditDto, IFormFile? ImageUrl) // güncelleme işini yapacaz 
        {
            if (appUserEditDto.Password == appUserEditDto.ConfirmPassword)//ikişfrede aynısı ise 
            {

                if (!ModelState.IsValid)
                {

                    if (ImageUrl is not null)
                    {
                        string klasor1 = Directory.GetCurrentDirectory() + "/wwwroot/Img/" + ImageUrl.FileName;
                        using var stream1 = new FileStream(klasor1, FileMode.Create);
                        ImageUrl.CopyTo(stream1);
                       appUserEditDto.ImageUrl = ImageUrl.FileName;
                    }  
                }
                var user = await _userManager.FindByNameAsync(User.Identity.Name);//username göre önceliğğinde hareket edecek

                user.Phone = appUserEditDto.Phone;
                user.LastName = appUserEditDto.LastName;
                user.About = appUserEditDto.About;
                user.Adress = appUserEditDto.Adress;
                user.Name = appUserEditDto.Name;
                user.ImageUrl = appUserEditDto.ImageUrl;
                user.Email = appUserEditDto.Email;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, appUserEditDto.Password);//şifremizi gene gizli bi şekide veri tabanımıza göndereecez bu kod sayesinde 
                var resut = await _userManager.UpdateAsync(user);
                if (resut.Succeeded) // eğer güncelleme başarılı ise loginin indexine yönlendir
                {
                    return RedirectToAction("Signİn", "Login");
                }

            }
            return View();
        }

    }
}
