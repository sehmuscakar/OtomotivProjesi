using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;

namespace BusinessLayer.Abstract
{
    public interface ICarKategoriManager
    {
        List<CarKategoriListDto> GetCarKategoriListManager();
        List<CarKategori> GetList();
        void Add(CarKategori carKategori);
        void Update(CarKategori carKategori);
        void Remove(CarKategori carKategori);
        CarKategori GetByID(int id);
    }
}
