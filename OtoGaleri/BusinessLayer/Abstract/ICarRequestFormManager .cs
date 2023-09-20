using DataAccessLayer.Entities;

namespace BusinessLayer.Abstract
{
    public interface ICarRequestFormManager
    {
        List<CarRequestForm> GetList();
        void Add(CarRequestForm carRequestForm);
        void Update(CarRequestForm carRequestForm);
        void Remove(CarRequestForm carRequestForm);
        CarRequestForm GetByID(int id);
    }
}
