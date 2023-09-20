using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace OtoGaleriPresentationLayer.ViewComponents
{
    public class HeroViewComponent:ViewComponent
    {

        private readonly ICarouselManager _heroManager;

        public HeroViewComponent(ICarouselManager heroManager)
        {
            _heroManager = heroManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listele = _heroManager.GetList();
            return View(listele);
        }
    }
}
