using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;

namespace BusinessLayer.Concrete
{
    public class BrandManager : IBrandManager
    {

        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
           brand.AppUserId = 1;
            var roworder = _brandDal.GetAll().Count();
            brand.RowOrder = roworder + 1;
            _brandDal.Add(brand);
        }

        public List<BrandListDto> GetBrandListManager()
        {
            return _brandDal.GetBrandListDal();
        }

        public Brand GetByID(int id)
        {
          return  _brandDal.Get(id);
        }

        public List<Brand> GetList()
        {
           return _brandDal.GetAll();
        }

        public void Remove(Brand brand)
        {
            _brandDal.Delete(brand);
        }

        public void Update(Brand brand)
        {
            brand.AppUserId = 1;
            var roworder = _brandDal.GetAll().Count();
           brand.RowOrder = roworder;
           brand.LastUpdatedAt = DateTime.Now;
            _brandDal.Update(brand);    
        }
    }
}
