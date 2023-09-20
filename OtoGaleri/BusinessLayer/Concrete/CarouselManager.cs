using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;

namespace BusinessLayer.Concrete
{
    public class CarouselManager : ICarouselManager
    {
        private readonly ICarouselDal _carouselDal;

        public CarouselManager(ICarouselDal carouselDal)
        {
            _carouselDal = carouselDal;
        }

        public void Add(Carousel hero)
        {
            hero.AppUserId = 1;
            var roworder = _carouselDal.GetAll().Count();
            hero.RowOrder = roworder + 1;
            _carouselDal.Add(hero);
        }

        public Carousel GetByID(int id)
        {
            return _carouselDal.Get(id);
        }

        public List<CarouselListDto> GetCarouselListManager()
        {
            return _carouselDal.GetCarouselListDal();
        }

        public List<Carousel> GetList()
        {
           return _carouselDal.GetAll();    
        }

        public void Remove(Carousel hero)
        {
            _carouselDal.Delete(hero);
        }

        public void Update(Carousel hero)
        {
            hero.AppUserId = 1;
            var roworder = _carouselDal.GetAll().Count();
          hero.RowOrder = roworder;
          hero.LastUpdatedAt = DateTime.Now;
            _carouselDal.Update(hero);    
        }
    }
}
