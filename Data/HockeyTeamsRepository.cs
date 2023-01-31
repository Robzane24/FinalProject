using MySql.Data.MySqlClient;
using Dapper;
using FinalProject.Data;
using FinalProject.Models;
using System.Data;

namespace FinalProject.Data
{
    public class HockeyTeamsRepository : IHockeyTeamsRepository
    {
        private IDbConnection _conn;
        public HockeyTeamsRepository(IDbConnection conn)
        {
            _conn = conn; 
        }
        

        public HockeyTeam GetHockeyTeamsDetail(int teamID)
        {
             var result = _conn.QuerySingle<HockeyTeam>("SELECT t.TeamID, t.TeamName, t.InceptionYear, t.Championships, m.MascotImage, f.TeamFact FROM teams as t\r\nJOIN mascot as m on t.TeamID = m.TeamID\r\nJOIN funfacts as f on t.TeamID = f.TeamID\r\nWHERE t.TeamID = @teamID", new { teamID = teamID });
            return result;
        }

        public IEnumerable<HockeyTeam> GetHockeyTeamsDetails()
        {
            return _conn.Query<HockeyTeam>("SELECT * FROM teams;");
        }

        public void UpdateTeam(HockeyTeam team)
        {
            _conn.Execute("UPDATE teams SET TeamName = @name, InceptionYear = @inceptionYear, Championships = @championships WHERE TeamID = @id",
            new { name = team.TeamName, inceptionYear = team.InceptionYear, championships = team.Championships, id = team.TeamID });
            
        }

        public void InsertHockeyTeam(HockeyTeam teamToInsert)
        {
            _conn.Execute("INSERT INTO teams (TeamName, InceptionYear, Championships) VALUES (@name, @inceptionyear, @championships);",
                new { name = teamToInsert.TeamName, inceptionyear = teamToInsert.InceptionYear, championships = teamToInsert.Championships });
        }

        public void DeleteHockeyTeam(HockeyTeam team)
        {
            _conn.Execute("DELETE FROM teams WHERE teamid = @id;", new { id = team.TeamID });
        }
        public IEnumerable<TeamCategory> GetTeamCategories()
        {
            return _conn.Query<TeamCategory>("SELECT * FROM teamcategory;");
        }

        public HockeyTeam TeamAssignment()
        {
            var teamList = GetTeamCategories();
            var team = new HockeyTeam();
            

            return team;
        }

        
    }
}
