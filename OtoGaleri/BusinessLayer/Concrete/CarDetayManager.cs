using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;

namespace BusinessLayer.Concrete
{
    public class CarDetayManager : ICarDetayManager
    {
        private readonly ICarDetayDal _carDetayDal;
        public CarDetayManager(ICarDetayDal carDetayDal)
        {
            _carDetayDal = carDetayDal;
        }

        public void Add(CarDetay carDetay)
        {
            carDetay.AppUserId = 1;
            var roworder = _carDetayDal.GetAll().Count();
            carDetay.RowOrder = roworder + 1;
            _carDetayDal.Add(carDetay);
        }

        public CarDetay GetByID(int id)
        {
            return _carDetayDal.Get(id);
        }

        public List<CarDetayListDto> GetCarDetayListManager()
        {
            return _carDetayDal.GetCarDetayListDal();
        }

        public List<CarDetay> GetList()
        {
            return _carDetayDal.GetAll();
        }

        public void Remove(CarDetay carDetay)
        {
           _carDetayDal.Delete(carDetay);
        }

        public void Update(CarDetay carDetay)
        {
            carDetay.AppUserId = 1;
            var roworder = _carDetayDal.GetAll().Count();
          carDetay.RowOrder = roworder;
          carDetay.LastUpdatedAt = DateTime.Now;
            _carDetayDal.Update(carDetay);
        }
    }
}
