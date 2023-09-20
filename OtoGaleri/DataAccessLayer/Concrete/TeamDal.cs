using CoreLayer.DataAccess.EntityFramwork;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Concrete
{
    public class TeamDal : BaseRepository<Team, ProjeContext>, ITeamDal
    {
        public List<TeamListDto> GetTeamListDal()
        {
            using (var context = new ProjeContext())
            {
                var a = context.Teams.Select(Team => new TeamListDto()
                {
                    Id = Team.Id,
                    FullName = Team.FullName,
                    Image = Team.Image,
                    Duty = Team.Duty,
                    Twitter = Team.Twitter,
                    Facebook = Team.Facebook,
                    Instegram = Team.Instegram,
                    LinkedIn = Team.LinkedIn,
                    LastUpdatedAt = Team.LastUpdatedAt,
                    CreatedFullName = Team.AppUser.Name,//bunu topbar appuser ilişkisinden userdan çektik
                    RowOrder = Team.RowOrder
                });
                return a.ToList();
            }
        }
    }
}
