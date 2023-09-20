using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace OtoGaleriPresentationLayer.ViewComponents
{
    public class BrandViewComponent:ViewComponent
    {

        private readonly IBrandManager _brandManager;

        public BrandViewComponent(IBrandManager brandManager)
        {
            _brandManager = brandManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listele = _brandManager.GetList();
            return View(listele);
        }

    }
}
