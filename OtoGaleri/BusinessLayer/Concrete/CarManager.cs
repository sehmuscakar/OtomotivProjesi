using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;

namespace BusinessLayer.Concrete
{
    public class CarManager : ICarManager
    {

        private readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
           car.AppUserId = 1;
            var roworder = _carDal.GetAll().Count();
           car.RowOrder = roworder + 1;
            _carDal.Add(car);
        }

        public Car GetByID(int id)
        {
            return _carDal.Get(id);
        }

        public List<CarListDto> GetCarListManager()
        {
            return _carDal.GetCarListDal();
        }

        public List<Car> GetList()
        {
            return _carDal.GetAll();
        }

        public void Remove(Car car)
        {
           _carDal.Delete(car);
        }

        public void Update(Car car)
        {
            car.AppUserId = 1;
            var roworder = _carDal.GetAll().Count();
           car.RowOrder = roworder;
           car.LastUpdatedAt = DateTime.Now;
            _carDal.Update(car);
        }
    }
}
