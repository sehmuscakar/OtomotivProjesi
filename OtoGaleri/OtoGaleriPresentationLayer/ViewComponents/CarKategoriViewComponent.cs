using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace OtoGaleriPresentationLayer.ViewComponents
{
    public class CarKategoriViewComponent:ViewComponent
    {

        private readonly ICarKategoriManager _carKategoriManager;

        public CarKategoriViewComponent(ICarKategoriManager carKategoriManager)
        {
            _carKategoriManager = carKategoriManager;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listele = _carKategoriManager.GetList();
            return View(listele);
        }

    }
}
