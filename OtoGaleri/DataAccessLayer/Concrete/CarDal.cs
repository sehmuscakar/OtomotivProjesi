using CoreLayer.DataAccess.EntityFramwork;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Dtos;
using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class CarDal : BaseRepository<Car, ProjeContext>, ICarDal
    {
        public List<CarListDto> GetCarListDal()
        {
            using (var context = new ProjeContext())
            {
                var a = context.Cars.Select(car => new CarListDto()
                {
                    Id = car.Id,
                    Title = car.Title,
                    ImageUrl = car.ImageUrl,
                    CarKategoriId = car.CarKategori.Id,
                    CarDetayId = car.CarDetayId,
                    CarKategoriName = car.CarKategori.Name,
                  
                    LastUpdatedAt = car.LastUpdatedAt,
                    CreatedFullName = car.AppUser.Name,//bunu topbar appuser ilişkisinden userdan çektik
                    RowOrder = car.RowOrder
                });
                return a.ToList();
            }
        }

    }
}
