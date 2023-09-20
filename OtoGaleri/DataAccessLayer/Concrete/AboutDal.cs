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
    public class AboutDal : BaseRepository<About, ProjeContext>, IAboutDal
    {
        public List<AboutListDto> GetAboutListDal()
        {
            using (var context = new ProjeContext())
            {
                var a = context.Abouts.Select(about=> new AboutListDto()
                {
                    Id = about.Id,
                    AboutDecription=about.AboutDecription,
                    ImageUrl=about.ImageUrl,
                    Title1= about.Title1,
                    Title12=about.Title12,
                    Title3=about.Title3,
                    LastUpdatedAt = about.LastUpdatedAt,
                    CreatedFullName = about.AppUser.Name,//bunu topbar appuser ilişkisinden userdan çektik
                    RowOrder = about.RowOrder
                });
                return a.ToList();
            }
        }
    }
}
