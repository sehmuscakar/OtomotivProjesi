using BusinessLayer.Abstract;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace OtoGaleriPresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class CarKategoriController : Controller
    {

        private readonly ICarKategoriManager _carKategoriManager;

        public CarKategoriController(ICarKategoriManager carKategoriManager)
        {
            _carKategoriManager = carKategoriManager;
        }

        // GET: CarKategoriController
        public async Task<IActionResult> Index()
        {
            //  var listele = _carKategoriManager.GetList();
            var listdto = _carKategoriManager.GetCarKategoriListManager();
            return View(listdto);
        }


        // GET: CarKategoriController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: CarKategoriController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarKategori carKategori)
        {
            try
            {
                _carKategoriManager.Add(carKategori);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception hata)
            {
                Console.WriteLine("Mesaj : " + hata.Message);
                return View();
            }
        }

        // GET: CarKategoriController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var datagetir = _carKategoriManager.GetByID(id);
            return View(datagetir);
        }

        // POST: CarKategoriController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CarKategori carKategori)
        {
            try
            {
                _carKategoriManager.Update(carKategori);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception hata)
            {
                Console.WriteLine("Mesaj : " + hata.Message);
                return View();
            }
        }

        // GET: CarKategoriController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var datagetir = _carKategoriManager.GetByID(id);
            return View(datagetir);
        }

        // POST: CarKategoriController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, CarKategori carKategori)
        {
            try
            {
                _carKategoriManager.Remove(carKategori);
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
