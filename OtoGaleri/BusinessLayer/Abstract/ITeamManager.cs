using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;

namespace BusinessLayer.Abstract
{
    public interface ITeamManager
    {
        List<TeamListDto> GetTeamListManager();
        List<Team> GetList();
        void Add(Team team);

        void Update(Team team);

        void Remove(Team team);

        Team GetById(int id);

    }
}
