using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Entities;

namespace BusinessLayer.Concrete
{
    public class CarRequestFormManager : ICarRequestFormManager
    {

        private readonly ICarRequestFormDal _carRequestFormDal;

        public CarRequestFormManager(ICarRequestFormDal carRequestFormDal)
        {
            _carRequestFormDal = carRequestFormDal;
        }

        public void Add(CarRequestForm carRequestForm)
        {     
            var roworder = _carRequestFormDal.GetAll().Count();
            carRequestForm.RowOrder = roworder + 1;
            _carRequestFormDal.Add(carRequestForm);
        }

        public CarRequestForm GetByID(int id)
        {
            return _carRequestFormDal.Get(id);
        }

        public List<CarRequestForm> GetList()
        {
            return _carRequestFormDal.GetAll();
        }

        public void Remove(CarRequestForm carRequestForm)
        {
           _carRequestFormDal.Delete(carRequestForm);
        }

        public void Update(CarRequestForm carRequestForm)
        {
            _carRequestFormDal.Update(carRequestForm);
        }
    }
}
