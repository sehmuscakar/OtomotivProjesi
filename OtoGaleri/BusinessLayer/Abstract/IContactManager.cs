using DataAccessLayer.Dtos;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactManager
    {
        //public HomeContactDto HomeContactCityEditManager();
        List<Contact> GetList();
        void Add(Contact contact);
        void Update(Contact contact);
        void Remove(Contact contact);
        Contact GetByID(int id);
    }
}
