using BusinessLayer.Abstract;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace OtoGaleriPresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class ContactCityController : Controller
    {

        private readonly IContactCityManager _contactCityManager;

        public ContactCityController(IContactCityManager contactCityManager)
        {
            _contactCityManager = contactCityManager;
        }

        // GET: ContactCityController
        public async Task<IActionResult> Index()
        {
            //  var listele = _contactCityManager.GetList();
            var listdto = _contactCityManager.GetContactCityListManager();
            return View(listdto);
        }

        // GET: ContactCityController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: ContactCityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContactCity contactCity)
        {
            try
            {
                _contactCityManager.Add(contactCity);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception hata)
            {
                Console.WriteLine("Mesaj : " + hata.Message);
                return View();
            }
        }

        // GET: ContactCityController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var datagetir=_contactCityManager.GetByID(id);
            return View(datagetir);
        }

        // POST: ContactCityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ContactCity contactCity)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception hata)
            {
                Console.WriteLine("Mesaj : " + hata.Message);
                return View();
            }
        }

        // GET: ContactCityController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var datagetir = _contactCityManager.GetByID(id);
            return View(datagetir);
        }

        // POST: ContactCityController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id,ContactCity contactCity)
        {
            try
            {
                _contactCityManager.Remove(contactCity);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception hata)
            {
                Console.WriteLine("Mesaj : " + hata.Message);
                return View();
            }
        }
    }
}
