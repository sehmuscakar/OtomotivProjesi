using CoreLayer.DataAccess.EntityFramwork;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Dtos;
using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class CarDetayDal : BaseRepository<CarDetay, ProjeContext>, ICarDetayDal
    {
        public List<CarDetayListDto> GetCarDetayListDal()
        {
            using (var context = new ProjeContext())
            {
                var a = context.CarDetays.Select(carDetay => new CarDetayListDto()
                { 
                Id = carDetay.Id,
                ImageUrl = carDetay.ImageUrl,
                Year = carDetay.Year,
                Km = carDetay.Km,
                Price = carDetay.Price,
                AdvertTime = carDetay.AdvertTime,
                Description= carDetay.Description,
                LastUpdatedAt = carDetay.LastUpdatedAt,
                CreatedFullName = carDetay.AppUser.Name,//bunu topbar appuser ilişkisinden userdan çektik
                RowOrder = carDetay.RowOrder
                });
                return a.ToList();
            }
        }
    }
}
