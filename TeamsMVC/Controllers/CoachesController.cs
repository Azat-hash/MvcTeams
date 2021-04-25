using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamsMVC.Context;
using TeamsMVC.Models;

namespace TeamsMVC.Controllers
{
    public class CoachesController : Controller
    {
        private TeamsContext db = new TeamsContext();

        // GET: Coaches
        public ActionResult Index()
        {
            return View(db.Coaches.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Teams = GetTeams();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Coach coach)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Teams = GetTeams();
                return View(coach);
            }

            db.Coaches.Add(coach);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Получить тренеров
        /// </summary>
        /// <returns></returns>
        private SelectList GetTeams()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Value = "null", Text = "Не выбрано" });
            list.AddRange(db.Teams
                .ToList()
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList());

            return new SelectList(list, "Value", "Text");
        }
    }
}