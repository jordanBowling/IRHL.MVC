using IRHL.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace IRHL.MVC.Controllers
{
    public class TeamController : Controller
    {
        //Add DB Context
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Team
        [HttpGet]
        public ActionResult Index()
        {
            List<Team> teamList = _db.Teams.ToList();
            List<Team> orderedList = teamList.OrderBy(team => team.TeamName).ToList();
            return View(orderedList);
        }

        //GET: Team
        public ActionResult Create()
        {
            return View();
        }

        //POST: Team
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Team team)
        {
            if (ModelState.IsValid)
            {
                _db.Teams.Add(team);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(team);
        }

        //GET: Delete
        //Team/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = _db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        //POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Team team = _db.Teams.Find(id);
            _db.Teams.Remove(team);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: Edit 
        //Team/Edit/{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = _db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        //POST: Edit
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Team team)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(team).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(team);
        }

        //GET: Details
        //Team/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Team team = _db.Teams.Find(id);

            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }
    }
}