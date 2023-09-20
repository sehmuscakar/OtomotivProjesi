using CoreLayer.DataAccess.EntityFramwork;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Concrete
{
    public class CarouselDal : BaseRepository<Carousel, ProjeContext>, ICarouselDal
    {
        public List<CarouselListDto> GetCarouselListDal()
        {
            using (var context = new ProjeContext())
            {
                var a = context.Carousels.Select(carousel => new CarouselListDto()
                {
                    Id= carousel.Id,
                    ImageUrl= carousel.ImageUrl,
                    Title1= carousel.Title1,
                    Title2= carousel.Title2,
                    LastUpdatedAt = carousel.LastUpdatedAt,
                    CreatedFullName = carousel.AppUser.Name,//bunu topbar appuser ilişkisinden userdan çektik
                    RowOrder = carousel.RowOrder

                });
                return a.ToList();
            }
        }
    }
}
