using BusinessLayer.Abstract;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OtoGaleriPresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class HeroController : Controller
    {
        private readonly ICarouselManager _heroManager;

        public HeroController(ICarouselManager heroManager)
        {
            _heroManager = heroManager;
        }
        public async Task<IActionResult> Index()
        {
            //  var listelle = _heroManager.GetList();
            var listdto = _heroManager.GetCarouselListManager();
            return View(listdto);
        }
        // GET: HeroController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: HeroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Carousel hero, IFormFile? ImageUrl)
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
                       hero.ImageUrl = ImageUrl.FileName;
                    }

                    _heroManager.Add(hero);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception hata)
            {
                Console.WriteLine("Mesaj : " + hata.Message);
                return View();
            }
        }

        // GET: HeroController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var datagetir = _heroManager.GetByID(id);
            return View(datagetir);
        }

        // POST: HeroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Carousel hero, IFormFile? ImageUrl)
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
                        hero.ImageUrl = ImageUrl.FileName;
                    }

                    _heroManager.Update(hero);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HeroController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var datagetir=_heroManager.GetByID(id);
            return View(datagetir);
        }

        // POST: HeroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Carousel hero)
        {
            try
            {
                _heroManager.Remove(hero);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
