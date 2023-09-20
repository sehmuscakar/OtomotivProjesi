using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Areas.Admin.Models;
using OtoGaleriPresentationLayer.Areas.Admin.Models;

namespace OtoGaleriPresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [AllowAnonymous]// bu bu controllerın erişilmesine imkan sunar
    //[Authorize] bu bu controllerı kilitler.
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;// bu ikisi hazır sınıflar ıdentity kütüphanesinin 
        private readonly UserManager<AppUser> _userManager;
        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Signİn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Signİn(LoginViewModel loginViewModel) // peek defination diyereek direk bu sayfanın içinden  o modelini dolduurabilirsin
        {
            var result = await _signInManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, true, true);//true,true ;1.ci true browser kapandıktan sonra sişfre hatırlansın mı
                                                                                                                                //2.ci true ise accessfailedcount nin aktif olması yani kullanıcı her yanlış girdiğinde 1 artacak ve 5 olduğunda onu loglayacak engeleyece beli süre aralığında 20 dk ciivarı herhalde bilmiyorum tam 
            if (result.Succeeded)
            {
                _userManager.FindByNameAsync(loginViewModel.Username);//kayıt olan username i bulur ,bu olmazsa appuser gti hep boş gelir ,bulamazmıyor çünkü,//kayıt olan username i bulur,burda 4 şeye göre bulur kayıt olan user 1.FindByIdAsync userıd ye göre

                return RedirectToAction("Index", "Hero");
            }


            return View();
        }


        [HttpGet]
        public IActionResult ConfirmMail() // 6 haneli kodu girmek için 
        {
            var value = TempData["Mail"];
            //	ViewBag.v=value+" aaaa"; // burda viewbag aracı ile ekleme yaptık tempdataya sonra bunu ilgili index te çağıracaz 
            ViewBag.v = value;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmMail(ConfirmMailViewModel confirmMailViewModel) //burda biz view model kullandık cok işe yaradı model view kullanımını araştır vievbag ,tempdata veri taşıma işlemleri gibi yani 
        {
            //var value = TempData["Mail"]; oladı taşınmadı böyle view model ile taşıdık confirmviewmodel
            var user = await _userManager.FindByEmailAsync(confirmMailViewModel.Mail);
            if (user.ConfirmCode == confirmMailViewModel.ConfirmCode)
            {
                user.EmailConfirmed = true; //güvenliği true yaptık
                await _userManager.UpdateAsync(user);// günceleme yapacak yani ypdate edip db ye yansıtacak
                return RedirectToAction("Signİn", "Login");
            }//email confirmen ksımı update edilip true ya dönecek
            return View();
        }



        public IActionResult Error404(int code)//program.cs te bu premtreeyi verdik
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> LogOut()//sistemden çıkış yapma
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Signİn", "Login");
        }

    }
}
