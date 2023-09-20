using DataAccessLayer.Dtos;
using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IContactCityManager
    {
        List<ContactCityListDto> GetContactCityListManager();
        List<ContactCity> GetList();
        void Add(ContactCity contactCity);
        void Update(ContactCity contactCity);

        void Remove(ContactCity contactCity);
        ContactCity GetByID(int id);


    }
}
