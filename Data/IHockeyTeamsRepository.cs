using FinalProject.Models;
using System.Data;

namespace FinalProject.Data
{
    public interface IHockeyTeamsRepository
    {
        public HockeyTeam GetHockeyTeamsDetail(int teamID);
        public IEnumerable<HockeyTeam> GetHockeyTeamsDetails();

        public IEnumerable<TeamCategory> GetTeamCategories();
        public void UpdateTeam(HockeyTeam team);

        public void InsertHockeyTeam(HockeyTeam teamToInsert);

        public void DeleteHockeyTeam(HockeyTeam team);

        public HockeyTeam TeamAssignment();
    }
}
