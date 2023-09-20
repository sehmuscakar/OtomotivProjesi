using CoreLayer.DataAccess;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICarouselDal:IEntityRepository<Carousel>
    {
        List<CarouselListDto> GetCarouselListDal();
    }
}
