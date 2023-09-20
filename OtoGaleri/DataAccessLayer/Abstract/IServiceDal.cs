using CoreLayer.DataAccess;
using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Abstract
{
    public interface IServiceDal:IEntityRepository<Service>
    {
        List<ServiceListDto> GetServiceListDal();
    }
}
