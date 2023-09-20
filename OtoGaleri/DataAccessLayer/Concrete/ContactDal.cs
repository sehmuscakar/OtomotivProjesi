using CoreLayer.DataAccess.EntityFramwork;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Dtos;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Concrete
{
    public class ContactDal : BaseRepository<Contact, ProjeContext>, IContactDal
    {
        //public HomeContactDto HomeContactCityEditDal()
        //{
        //    using (var context = new ProjeContext())
        //    {
        //        var NewContact = new HomeContactDto
        //        {
                 
                    

        //        };
        //        context.Contacts.Add(NewContact.Contact);
        //        context.SaveChanges();
        //        return NewContact;
        //    }
        //}
    }
}
