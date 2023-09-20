using CoreLayer.DataAccess;
using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Abstract
{
    public interface ITeamDal:IEntityRepository<Team>
    {
        List<TeamListDto> GetTeamListDal();

    }
}
