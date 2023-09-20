using BusinessLayer.Abstract;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace OtoGaleriPresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class CarRequestFormController : Controller
    {
        private readonly ICarRequestFormManager _carRequestFormManager;

        public CarRequestFormController(ICarRequestFormManager carRequestFormManager)
        {
            _carRequestFormManager = carRequestFormManager;
        }

        // GET: CarRequestFormController
        public async Task<IActionResult> Index()
        {
            var listele = _carRequestFormManager.GetList();
            return View(listele);
        }


        // GET: CarRequestFormController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: CarRequestFormController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarRequestForm carRequestForm)
        {
            try
            {
                _carRequestFormManager.Add(carRequestForm);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception hata)
            {
                Console.WriteLine("Mesaj : " + hata.Message);
                return View();
            }
        }

        // GET: CarRequestFormController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var datagetir = _carRequestFormManager.GetByID(id);
            return View(datagetir);
        }

        // POST: CarRequestFormController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CarRequestForm carRequestForm)
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

        // GET: CarRequestFormController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var datagetir = _carRequestFormManager.GetByID(id);
            return View(datagetir);
        }

        // POST: CarRequestFormController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, CarRequestForm carRequestForm)
        {
            try
            {
                _carRequestFormManager.Remove(carRequestForm);
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
