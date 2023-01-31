using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class HockeyTeamsController : Controller
    {

        private readonly IHockeyTeamsRepository _repo;

        public HockeyTeamsController(IHockeyTeamsRepository repo)
        {
            _repo = repo;
        }


        public IActionResult ViewHockeyTeam(int teamId)
        {
            var team = _repo.GetHockeyTeamsDetail(teamId);
            return View(team);
        }

        public IActionResult Index()
        {
            var team = _repo.GetHockeyTeamsDetails();
            return View(team);  
        }

        public IActionResult UpdateTeam(int id)
        {
            HockeyTeam team = _repo.GetHockeyTeamsDetail(id);
            if (team == null)
            {
                return View("TeamNotFound");
            }
            return View(team);
        }

        public IActionResult UpdateHockeyTeamToDatabase(HockeyTeam team)
        {
            _repo.UpdateTeam(team);

            return RedirectToAction("ViewHockeyTeam", new { id = team.TeamID });
        }

        public IActionResult InsertHockeyTeam()
        {

            var team = _repo.TeamAssignment();
            return View(team);
        }
        public IActionResult InsertHockeyTeamToDatabase(HockeyTeam teamToInsert)
        {
            _repo.InsertHockeyTeam(teamToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteHockeyTeam(HockeyTeam team)
        {
            _repo.DeleteHockeyTeam(team);
            return RedirectToAction("Index");
        }



    }
}