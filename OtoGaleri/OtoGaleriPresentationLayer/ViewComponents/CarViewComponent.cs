using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace OtoGaleriPresentationLayer.ViewComponents
{
    public class CarViewComponent:ViewComponent
    {
        private readonly ICarManager _carManager;
        public CarViewComponent(ICarManager carManager)
        {
            _carManager = carManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listele = _carManager.GetCarListManager();
            return View(listele);
        }
    }
}
