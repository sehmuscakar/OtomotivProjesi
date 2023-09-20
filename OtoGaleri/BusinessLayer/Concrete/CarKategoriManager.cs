using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;

namespace BusinessLayer.Concrete
{
    public class CarKategoriManager : ICarKategoriManager
    {
        private readonly ICarKategoriDal _carKategoriDal;

        public CarKategoriManager(ICarKategoriDal carKategoriDal)
        {
            _carKategoriDal = carKategoriDal;
        }

        public void Add(CarKategori carKategori)
        {
            carKategori.AppUserId = 1;
            var roworder = _carKategoriDal.GetAll().Count();
            carKategori.RowOrder = roworder + 1;
            _carKategoriDal.Add(carKategori);
        }

        public CarKategori GetByID(int id)
        {
           return _carKategoriDal.Get(id);
        }

        public List<CarKategoriListDto> GetCarKategoriListManager()
        {
            return _carKategoriDal.GetCarKategoriListDal();
        }

        public List<CarKategori> GetList()
        {
            return _carKategoriDal.GetAll();
        }

        public void Remove(CarKategori carKategori)
        {
            _carKategoriDal.Delete(carKategori);    
        }

        public void Update(CarKategori carKategori)
        {
            carKategori.AppUserId = 1;
            var roworder = _carKategoriDal.GetAll().Count();
           carKategori.RowOrder = roworder;
           carKategori.LastUpdatedAt = DateTime.Now;
            _carKategoriDal.Update(carKategori);
        }
    }
}
