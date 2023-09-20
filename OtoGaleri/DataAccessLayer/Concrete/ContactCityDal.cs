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
    public class ContactCityDal : BaseRepository<ContactCity, ProjeContext>, IContactCityDal
    {
        public List<ContactCityListDto> GetContactCityListDal()
        {
            using (var context = new ProjeContext())
            {
                var a = context.ContactCities.Select(contactCity => new ContactCityListDto()
                {
                    Id = contactCity.Id,
                    Address= contactCity.Address,
                    MailCity= contactCity.MailCity,
                    Phone= contactCity.Phone,
                    Twiter=contactCity.Twiter,
                    Facebook=contactCity.Facebook,
                    Instegram=contactCity.Instegram,
                    Linkedin=contactCity.Linkedin,
                    Skype=contactCity.Skype,                  
                    LastUpdatedAt = contactCity.LastUpdatedAt,
                    CreatedFullName = contactCity.AppUser.Name,//bunu topbar appuser ilişkisinden userdan çektik
                    RowOrder =contactCity.RowOrder
                });
                return a.ToList();
            }
        }
    }
}
