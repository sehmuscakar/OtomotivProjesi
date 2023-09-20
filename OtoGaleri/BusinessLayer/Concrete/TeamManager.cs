using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;

namespace BusinessLayer.Concrete
{
    public class TeamManager : ITeamManager
    {
        private readonly ITeamDal _teamDal;
        public TeamManager(ITeamDal teamDal)
        {
            _teamDal = teamDal;
        }
        public void Add(Team team)
        {
            team.AppUserId = 1;
            var roworder = _teamDal.GetAll().Count();
            team.RowOrder = roworder + 1;
            _teamDal.Add(team);
        }
        public Team GetById(int id)
        {
            return _teamDal.Get(id);
        }
        public List<Team> GetList()
        {
            return _teamDal.GetAll();
        }
        public List<TeamListDto> GetTeamListManager()
        {
            return _teamDal.GetTeamListDal();
        }
        public void Remove(Team team)
        {
         _teamDal.Delete(team);
        }
        public void Update(Team team)
        {
            team.AppUserId = 1;
            var roworder = _teamDal.GetAll().Count();
            team.RowOrder = roworder;
            team.LastUpdatedAt = DateTime.Now;
            _teamDal.Update(team);
        }
    }
}
