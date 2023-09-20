using CoreLayer.DataAccess.EntityFramwork;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class BrandDal : BaseRepository<Brand, ProjeContext>, IBrandDal
    {
        public List<BrandListDto> GetBrandListDal()
        {
            using (var context = new ProjeContext())
            {
                var a = context.Brands.Select(Brand => new BrandListDto()
                {
                    Id = Brand.Id,
                    ImageUrl = Brand.ImageUrl,
                    LastUpdatedAt = Brand.LastUpdatedAt,
                    CreatedFullName = Brand.AppUser.Name,//bunu topbar appuser ilişkisinden userdan çektik
                    RowOrder = Brand.RowOrder
                });
                return a.ToList();
            }
        }
    }
}
