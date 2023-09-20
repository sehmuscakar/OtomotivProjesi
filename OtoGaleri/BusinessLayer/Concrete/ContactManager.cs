using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Entities;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactManager
    {

        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void Add(Contact contact)
        {
            var roworder = _contactDal.GetAll().Count();
          contact.RowOrder = roworder + 1;

            _contactDal.Add(contact);
        }

        public Contact GetByID(int id)
        {
            return _contactDal.Get(id);
        }

        public List<Contact> GetList()
        {
            return _contactDal.GetAll();
        }

        //public HomeContactDto HomeContactCityEditManager()
        //{

        //  return  _contactDal.HomeContactCityEditDal();
        //}

        public void Remove(Contact contact)
        {
           _contactDal.Delete(contact);
        }

        public void Update(Contact contact)
        {
            _contactDal.Update(contact);
        }
    }
}
