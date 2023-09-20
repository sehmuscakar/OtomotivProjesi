using CoreLayer.DataAccess;
using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Abstract
{
    public interface IAboutDal:IEntityRepository<About>
    {
        List<AboutListDto> GetAboutListDal();
    }
}
