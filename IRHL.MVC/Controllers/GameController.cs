using IRHL.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace IRHL.MVC.Controllers
{
    public class GameController : Controller
    {
        //Add DB Context
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Game
        public ActionResult Index()
        {
            List<Game> gameList = _db.Games.ToList();
            List<Game> orderedList = gameList.OrderBy(game => game.GameID).ToList();
            return View(orderedList);
        }

        //GET: Game
        public ActionResult Create()
        {
            return View();
        }

        //POST: Game
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Game game)
        {
            if (ModelState.IsValid)
            {
                _db.Games.Add(game);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(game);
        }

        //GET: Delete
        //Game/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = _db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        //POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Game game = _db.Games.Find(id);
            _db.Games.Remove(game);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: Edit
        //Game/Edit/{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = _db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        //POST: Edit
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Game game)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(game).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(game);
        }

        //GET: Details
        //Game/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Game game = _db.Games.Find(id);

            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }








    }
}