using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace OtoGaleriPresentationLayer.ViewComponents
{
    public class AboutViewComponent:ViewComponent
    {
        private readonly IAboutManager _aboutManager;

        public AboutViewComponent(IAboutManager aboutManager)
        {
            _aboutManager = aboutManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listele = _aboutManager.GetList();
            return View(listele);
        }
    }
}
