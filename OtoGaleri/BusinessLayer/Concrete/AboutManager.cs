using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutManager
    {

        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void Add(About about)
        {
            about.AppUserId = 1;    
            var roworder = _aboutDal.GetAll().Count();
            about.RowOrder = roworder + 1;
            _aboutDal.Add(about);    
        }

        public List<AboutListDto> GetAboutListManager()
        {
            return _aboutDal.GetAboutListDal();
        }

        public About GetByID(int id)
        {
            return _aboutDal.Get(id);
        }

        public List<About> GetList()
        {
            return _aboutDal.GetAll();
        }

        public void Remove(About about)
        {
            _aboutDal.Delete(about);
        }

        public void Update(About about)
        {
            about.AppUserId = 1;     
            var roworder = _aboutDal.GetAll().Count();
            about.RowOrder = roworder;
            about.LastUpdatedAt = DateTime.Now;
            _aboutDal.Update(about);
        }
    }
}
