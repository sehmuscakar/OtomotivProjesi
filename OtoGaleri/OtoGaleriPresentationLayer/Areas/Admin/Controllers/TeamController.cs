using BusinessLayer.Abstract;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Tesisat.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
  //  [Authorize]// giriş olmadan bu controllera erişilemez anlamında 
    public class TeamController : Controller
    {
        private readonly ITeamManager _teamManager;
        public TeamController(ITeamManager teamManager)
        {
            this._teamManager = teamManager;
        }
        // GET: TemaController
        public async Task<IActionResult> Index()
        {
            // var list=   _teamManager.GetList();
            var listdto = _teamManager.GetTeamListManager();   
            return View(listdto);
        }

        // GET: TemaController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: TemaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<IActionResult> Create(Team team,IFormFile? Image)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    if (Image is not null)
                    {
                        string klasor1 = Directory.GetCurrentDirectory() + "/wwwroot/Img/" + Image.FileName;
                        using var stream1 = new FileStream(klasor1, FileMode.Create);
                        Image.CopyTo(stream1);
                        team.Image = Image.FileName;
                    }
                    _teamManager.Add(team);
                }
         
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TemaController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var listele = _teamManager.GetById(id);
            return View(listele);
        }

        // POST: TemaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Team team, IFormFile? Image)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    if (Image is not null)
                    {
                        string klasor1 = Directory.GetCurrentDirectory() + "/wwwroot/Img/" + Image.FileName;
                        using var stream1 = new FileStream(klasor1, FileMode.Create);
                        Image.CopyTo(stream1);
                        team.Image = Image.FileName;
                    }
                    _teamManager.Update(team);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TemaController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var listele = _teamManager.GetById(id);
            return View(listele);
        }

        // POST: TemaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Team team)
        {
            try
            {

                _teamManager.Remove(team);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
