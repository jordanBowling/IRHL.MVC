using IRHL.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return View(_db.Teams.ToList());
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
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
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
            Team team = _db.Teams.Find();
            _db.Teams.Remove(team);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}