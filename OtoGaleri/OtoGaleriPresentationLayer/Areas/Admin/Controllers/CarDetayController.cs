using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace OtoGaleriPresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class CarDetayController : Controller
    {
        private readonly ICarDetayManager _carDetayManager;

        public CarDetayController(ICarDetayManager carDetayManager)
        {
            _carDetayManager = carDetayManager;
        }

        // GET: CarDetayController
        public async Task<IActionResult> Index()
        {
            //  var listele = _carDetayManager.GetList();
            var listdto = _carDetayManager.GetCarDetayListManager();
            return View(listdto);
        }



        // GET: CarDetayController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: CarDetayController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarDetay carDetay, IFormFile? ImageUrl)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    if (ImageUrl is not null)
                    {
                        string klasor1 = Directory.GetCurrentDirectory() + "/wwwroot/Img/" + ImageUrl.FileName;
                        using var stream1 = new FileStream(klasor1, FileMode.Create);
                        ImageUrl.CopyTo(stream1);
                        carDetay.ImageUrl = ImageUrl.FileName;
                    }

                    _carDetayManager.Add(carDetay);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception hata)
            {
                Console.WriteLine("Mesaj : " + hata.Message);
                return View();
            }
        }

        // GET: CarDetayController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var datagetir = _carDetayManager.GetByID(id);
            return View(datagetir);
        }

        // POST: CarDetayController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CarDetay carDetay, IFormFile? ImageUrl)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    if (ImageUrl is not null)
                    {
                        string klasor1 = Directory.GetCurrentDirectory() + "/wwwroot/Img/" + ImageUrl.FileName;
                        using var stream1 = new FileStream(klasor1, FileMode.Create);
                        ImageUrl.CopyTo(stream1);
                        carDetay.ImageUrl = ImageUrl.FileName;
                    }

                    _carDetayManager.Update(carDetay);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception hata)
            {
                Console.WriteLine("Mesaj : " + hata.Message);
                return View();
            }
        }

        // GET: CarDetayController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var datagetir = _carDetayManager.GetByID(id);
            return View(datagetir);
        }

        // POST: CarDetayController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, CarDetay carDetay)
        {
            try
            {
                _carDetayManager.Remove(carDetay);
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
