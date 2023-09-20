using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;

namespace BusinessLayer.Abstract
{
    public interface ICarDetayManager
    {
        List<CarDetayListDto> GetCarDetayListManager();
        List<CarDetay> GetList();
        void Add(CarDetay carDetay);
        void Update(CarDetay carDetay);
        void Remove(CarDetay carDetay);
        CarDetay GetByID(int id);
    }
}
