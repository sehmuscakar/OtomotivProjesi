using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        private readonly IContactCityManager _contactCityManager;

        public FooterViewComponent(IContactCityManager contactCityManager)
        {
            _contactCityManager = contactCityManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listele = _contactCityManager.GetList();
            return View(listele);
        }

    }
}
