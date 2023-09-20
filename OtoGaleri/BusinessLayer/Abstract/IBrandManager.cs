using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;

namespace BusinessLayer.Abstract
{
    public interface IBrandManager
    {
        List<BrandListDto> GetBrandListManager();
        List<Brand> GetList();
        void Add(Brand brand);
        void Update(Brand brand);
        void Remove(Brand brand);
        Brand GetByID(int id);

    }
}
