using CoreLayer.DataAccess.EntityFramwork;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Concrete
{
    public class CarKategoriDal : BaseRepository<CarKategori, ProjeContext>, ICarKategoriDal
    {
        public List<CarKategoriListDto> GetCarKategoriListDal()
        {
            using (var context = new ProjeContext())
            {
                var a = context.CarKategoris.Select(carKategori => new CarKategoriListDto()
                {
                    Id = carKategori.Id,
                    Name = carKategori.Name,
        

                    LastUpdatedAt = carKategori.LastUpdatedAt,
                    CreatedFullName = carKategori.AppUser.Name,//bunu topbar appuser ilişkisinden userdan çektik
                    RowOrder = carKategori.RowOrder
                });
                return a.ToList();
            }
        }
    }
}
