using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamsMVC.Context;
using System.Data.Entity;
using TeamsMVC.Enums;
using TeamsMVC.Models;
using TeamsMVC.Models.ViewModels;
using TeamsMVC.Helpers;
using AutoMapper;
using System.Threading.Tasks;

namespace TeamsMVC.Controllers
{
    public class PlayersController : Controller
    {
        public TeamsContext db = new TeamsContext();
        // GET: Players
        public ActionResult Index(int? teamId, Position? position)
        {
            var players = db.Players.Include(x => x.Team);
            if(teamId != null && teamId != 0)
            {
                players = players.Where(x => x.TeamId == teamId);
            }

            if(position != null)
            {
                players = players.Where(x => x.Position == position);
            }

            var listViewModel = GetPlayersListViewModel(players);
            return View(listViewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Positions = GetPositions();
            ViewBag.Teams = GetTeams();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Player player)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Positions = GetPositions();
                ViewBag.Teams = GetTeams();
                return View(player);
            }

            db.Players.Add(player);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            var player = db.Players
                .Include(x => x.Team)
                .Include(x => x.PlayerAntropometrics)
                .FirstOrDefault(x => x.Id == id);
            if (player == null)
                return HttpNotFound();

            return View(player);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var player = db.Players.Find(id);
            var config = new MapperConfiguration(x => x.CreateMap<Player, PlayerViewModel>());
            var mapper = new Mapper(config);

            var playerViewModel = mapper.Map<PlayerViewModel>(player);
            ViewBag.Teams = GetTeams();
            ViewBag.Positions = GetPositions();

            return View(playerViewModel);
        }

        [HttpPost]
        public ActionResult Edit(PlayerViewModel playerViewModel)
        {
            var player = db.Players.Find(playerViewModel.Id);
            if (player == null)
                return HttpNotFound();

            if (!ModelState.IsValid)
            {
                ViewBag.Teams = GetTeams();
                ViewBag.Positions = GetPositions(); 
                return View(playerViewModel);
            }

            var config = new MapperConfiguration(x => x.CreateMap<PlayerViewModel, Player>());
            var mapper = new Mapper(config);

            player = mapper.Map<Player>(playerViewModel);
            db.Entry(player).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAntropometrics(int id)
        {
            var playerInfo = db.PlayerAntropometrics.Include(x => x.Player).FirstOrDefault(x => x.PlayerId == id);
            if (playerInfo == null)
                playerInfo = new PlayerAntropometrics() { PlayerId = id };

            var config = new MapperConfiguration(x => x.CreateMap<PlayerAntropometrics, PlayerAntopometricsViewModel>());
            var mapper = new Mapper(config);

            var antropometricsViewModel = mapper.Map<PlayerAntopometricsViewModel>(playerInfo);
            ViewBag.FullName = playerInfo.Player?.FullName ?? "Не известно";
            return View(antropometricsViewModel);
        }

        [HttpPost]
        public ActionResult EditAntropometrics(PlayerAntopometricsViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var playerAntropometricsExists = (db.PlayerAntropometrics
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == model.Id)) != null;

            var config = new MapperConfiguration(x => x.CreateMap<PlayerAntopometricsViewModel, PlayerAntropometrics>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PlayerId)));
            var mapper = new Mapper(config);
            var playerInfo = mapper.Map<PlayerAntropometrics>(model);

            if (playerAntropometricsExists)
                db.Entry(playerInfo).State = EntityState.Modified;
            else
                db.PlayerAntropometrics.Add(playerInfo);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        private PlayersListViewModel GetPlayersListViewModel(IQueryable<Player> players)
        {
            return new PlayersListViewModel
            {
                Players = players.ToList(),
                Teams = GetTeams(),
                Positions = GetPositions()
            };
        }

        private SelectList GetPositions()
        {
            var positionsEnum = Enum.GetValues(typeof(Position))
                .Cast<Position>()
                .Select(v => new SelectListItem
                {
                    Text = v.GetDisplayName(),
                    Value = ((int)v).ToString()
                }).ToList();
            positionsEnum.Insert(0, new SelectListItem { Text = "Не выбрано", Value = null });
            return new SelectList(positionsEnum, "Value", "Text");
        }

        private SelectList GetTeams()
        {
            var teams = db.Teams.ToList().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            teams.Insert(0, new SelectListItem { Text = "Не выбрано", Value = null });
            return new SelectList(teams, "Value", "Text");
        }
    }
}