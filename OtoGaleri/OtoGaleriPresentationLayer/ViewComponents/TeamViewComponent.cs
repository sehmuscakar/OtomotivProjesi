using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace OtoGaleriPresentationLayer.ViewComponents
{
    public class TeamViewComponent:ViewComponent
    {
        private readonly ITeamManager _teamManager;

        public TeamViewComponent(ITeamManager teamManager)
        {
            _teamManager = teamManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listele = _teamManager.GetList();
            return View(listele);
        }
    }
}
