using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;

namespace BusinessLayer.Concrete
{
    public class ContactCityManager : IContactCityManager
    {
        private readonly IContactCityDal _contactCityDal;

        public ContactCityManager(IContactCityDal contactCityDal)
        {
            _contactCityDal = contactCityDal;
        }

        public void Add(ContactCity contactCity)
        {
            contactCity.AppUserId = 1;
            var roworder = _contactCityDal.GetAll().Count();
            contactCity.RowOrder = roworder + 1;
            _contactCityDal.Add(contactCity);
        }

        public ContactCity GetByID(int id)
        {
          return  _contactCityDal.Get(id);
        }

        public List<ContactCityListDto> GetContactCityListManager()
        {
            return _contactCityDal.GetContactCityListDal();
        }

        public List<ContactCity> GetList()
        {
          return  _contactCityDal.GetAll();
        }
        public void Remove(ContactCity contactCity)
        {
            _contactCityDal.Delete(contactCity);
        }
        public void Update(ContactCity contactCity)
        {
            contactCity.AppUserId = 1;
            var roworder = _contactCityDal.GetAll().Count();
          contactCity.RowOrder = roworder;
          contactCity.LastUpdatedAt = DateTime.Now;
            _contactCityDal.Update(contactCity);
        }
    }
}
