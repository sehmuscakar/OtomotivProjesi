using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;

namespace BusinessLayer.Abstract
{
    public interface ICarouselManager
    {
        List<CarouselListDto> GetCarouselListManager();
        List<Carousel> GetList();
        void Add(Carousel hero);
        void Update(Carousel hero);
        void Remove(Carousel hero);
        Carousel GetByID(int id);

    }
}
