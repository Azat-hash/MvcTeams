using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamsMVC.Context;
using TeamsMVC.Models;
using System.Data.Entity;

namespace TeamsMVC.Controllers
{
    public class TeamsController : Controller
    {
        private TeamsContext db = new TeamsContext();

        // GET: Teams
        public ActionResult Index()
        {
            return View(db.Teams.ToList());
        }      

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Sponsors = db.Sponsors.ToList();
            ViewBag.Coaches = GetCoaches();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Team team, int[] selectedSponsors)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Coaches = GetCoaches();
                return View(team);
            }
            if(selectedSponsors != null)
            {
                foreach (var sponsorId in selectedSponsors)
                {
                    var sponsor = db.Sponsors.Find(sponsorId);
                    team.Sponsors.Add(sponsor);
                }
            }
            
            db.Teams.Add(team);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            var team = db.Teams.Include(x => x.Sponsors).FirstOrDefault(x => x.Id == id);
            if (team == null)
                return HttpNotFound();

            ViewBag.Coaches = GetCoaches();
            ViewBag.Sponsors = db.Sponsors.ToList();
            return View(team);
        }
        
        [HttpPost]
        public ActionResult Edit(Team team, int[] selectedSponsors)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Coaches = GetCoaches();
                ViewBag.Sponsors = db.Sponsors.ToList();
                return View(team);
            }

            var newTeam = db.Teams.Find(team.Id);
            newTeam.CoachId = team.CoachId;
            newTeam.Conference = team.Conference;
            newTeam.Name = team.Name;
            newTeam.Sponsors.Clear();
            if (selectedSponsors != null)
            {
                foreach (var sponsorId in selectedSponsors)
                {
                    var sponsor = db.Sponsors.Find(sponsorId);
                    newTeam.Sponsors.Add(sponsor);
                }
            }

            db.Entry(newTeam).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Получить тренеров
        /// </summary>
        /// <returns></returns>
        private SelectList GetCoaches()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Value = null, Text = "Не выбрано" });
            list.AddRange(db.Coaches
                .ToList()
                .Select(x => new SelectListItem 
                {
                    Text = x.FullName,
                    Value = x.Id.ToString()
                }).ToList());

            return new SelectList(list, "Value", "Text");
        }
    }
}