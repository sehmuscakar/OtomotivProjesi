using BusinessLayer.Abstract;
using DataAccessLayer.Dtos;
using DataAccessLayer.Entities;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using OtoGaleriPresentationLayer.Models;
using System.Diagnostics;

namespace OtoGaleriPresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarManager _carManager;
        private readonly ICarKategoriManager _carKategoriManager;
        private readonly ICarDetayManager _carDetayManager;
        private readonly IContactManager _contactManager;
        private readonly IContactCityManager _contactCityManager;
        private readonly ICarRequestFormManager _carRequestFormManager;
        public HomeController(ICarManager carManager, ICarKategoriManager carKategoriManager, ICarDetayManager carDetayManager, IContactManager contactManager, IContactCityManager contactCityManager, ICarRequestFormManager carRequestFormManager)
        {
            _carManager = carManager;
            _carKategoriManager = carKategoriManager;
            _carDetayManager = carDetayManager;
            _contactManager = contactManager;
            _contactCityManager = contactCityManager;
            _carRequestFormManager = carRequestFormManager;
        }

        public async Task<IActionResult> Anasayfa() // Analayouta bağlı olan kısımlar burdamn çekilecek zaten
        {
            return View();
        }

        public async Task<IActionResult> About() // bunlar menu layota bağlı olacak 
        {
            return View();
        }
        public async Task<IActionResult> Service()
        {
            return View();
        }
        public async Task<IActionResult> Team() 
        {
            return View();
        }

        public async Task<IActionResult> CarKategori()
        {
            return View(_carKategoriManager.GetList());
        }

        public async Task<IActionResult> Car()
        {
            return View();
        }

        public async Task<IActionResult> CarDetay(int id)
        {
            //var carDetay = new CarDetay
            //{             
            //    CarGaleris = new List<CarGaleri>()

            //};
            //for (int i = 1; i <= 5; i++)
            //{
            //    carDetay.CarGaleris.Add(new CarGaleri { ImageUrl = $"{i}" });
            //}

            // Görünümü ve modeli döndürün
            //return View(carDetay);
            var datagetir = _carDetayManager.GetByID(id);
            return View(datagetir);
        }

        public async Task<IActionResult> Contact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Contact(Contact contact)
        {

            //gönderilecek olan kişin bilgileri
            MimeMessage mimeMessage = new MimeMessage();// minekit kütüphanesi eklemen lazım bunun için maile doğrulama yapmak için 

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Web'ten Mesajınız", "scakar542@gmail.com");//kimden geleceği isim ve mail

            mimeMessage.From.Add(mailboxAddressFrom);//kimden gelecek ekle
                                                     //alacak olan kişin bilgileri
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", contact.Mail);//kime gideği isim ve adres

            mimeMessage.To.Add(mailboxAddressTo);//kime gidecek ekle

            //  mimeMessage.Subject = contact.Subject;// bu direk mail başlığında yazar
            mimeMessage.Subject = "Çakar Otomotiv";// bu direk mail başlığında yazar

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = "Gönderen Adı: " + contact.Name + "***" + "Konu: " + contact.Subject + "***" + "Gönderilen Mesaj: " + contact.Message;
            mimeMessage.Body = bodyBuilder.ToMessageBody();   //mesaja ekle body kısmına 

            //mimeMessage.Subject = "Easy Cash Onay Kodu";//konu kısmı

            SmtpClient client = new SmtpClient();// mail trnsfer nesne örneği protokol
            client.Connect("smtp.gmail.com", 587, false);//prokol gereklikleri bağlantı kurma ,burda bağlatı güvenliğine false dedik çünkü ConfirmMailController da true işlemi yapacaz emailconfirmed

            client.Authenticate("scakar542@gmail.com", "ulfk tsio amki rqob");//mail ve mailde oluşturduğun güvenlik kodu,bunu her bir ayrı projede ayrı al bu güvenlik kodunu mail üzerinden bazı işlmlerle alırsın
            client.Send(mimeMessage);//gönder
            client.Disconnect(true);//gövenli çıkış yap 
                                    //bu işlemi yapman için iki adımlı doğrulamyı mail de açman lazım
            _contactManager.Add(contact);
            return View();
        }

     
        public async Task<IActionResult> CarRequestForm()
        {
          
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CarRequestForm(CarRequestForm carRequestForm)
        {
            //gönderilecek olan kişin bilgileri
            MimeMessage mimeMessage = new MimeMessage();// minekit kütüphanesi eklemen lazım bunun için maile doğrulama yapmak için 

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Web'ten Araç Talep İsteği", "scakar542@gmail.com");//kimden geleceği isim ve mail

            mimeMessage.From.Add(mailboxAddressFrom);//kimden gelecek ekle
                                                     //alacak olan kişin bilgileri
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", carRequestForm.Mail);//kime gideği isim ve adres

            mimeMessage.To.Add(mailboxAddressTo);//kime gidecek ekle

            //  mimeMessage.Subject = contact.Subject;// bu direk mail başlığında yazar
            mimeMessage.Subject = "Çakar Otomotiv";// bu direk mail başlığında yazar

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = "Gönderen Adı ve Soyadı: " + carRequestForm.FullName + "***" + "Telefon: " + carRequestForm.Phone + "***" + "Gönderilen Mesaj: " + carRequestForm.Description;
            mimeMessage.Body = bodyBuilder.ToMessageBody();   //mesaja ekle body kısmına 

            //mimeMessage.Subject = "Easy Cash Onay Kodu";//konu kısmı

            SmtpClient client = new SmtpClient();// mail trnsfer nesne örneği protokol
            client.Connect("smtp.gmail.com", 587, false);//prokol gereklikleri bağlantı kurma ,burda bağlatı güvenliğine false dedik çünkü ConfirmMailController da true işlemi yapacaz emailconfirmed

            client.Authenticate("scakar542@gmail.com", "ulfk tsio amki rqob");//mail ve mailde oluşturduğun güvenlik kodu,bunu her bir ayrı projede ayrı al bu güvenlik kodunu mail üzerinden bazı işlmlerle alırsın
            client.Send(mimeMessage);//gönder
            client.Disconnect(true);//gövenli çıkış yap 
                                    //bu işlemi yapman için iki adımlı doğrulamyı mail de açman lazım
           _carRequestFormManager.Add(carRequestForm);
            return View();
        }

        
    }
}