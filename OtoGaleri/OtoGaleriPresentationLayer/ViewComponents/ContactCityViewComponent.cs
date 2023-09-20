using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace OtoGaleriPresentationLayer.ViewComponents
{
    public class ContactCityViewComponent:ViewComponent
    {
        private readonly IContactCityManager _contactCityManager;

        public ContactCityViewComponent(IContactCityManager contactCityManager)
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
