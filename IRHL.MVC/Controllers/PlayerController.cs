using IRHL.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace IRHL.MVC.Controllers
{
    public class PlayerController : Controller
    {
        //Add Db Context
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Player
        public ActionResult Index()
        {
            List<Player> playerList = _db.Players.ToList();
            List<Player> orderedList = playerList.OrderBy(player => player.LastName).ToList();
            return View(orderedList);
        }

        //GET: Player
        public ActionResult Create()
        {
            return View();
        }

        //POST: Player
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Player player)
        {
            if (ModelState.IsValid)
            {
                _db.Players.Add(player);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(player);
        }

        //GET: Delete
        //Player/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = _db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        //POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Player player = _db.Players.Find(id);
            _db.Players.Remove(player);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: Edit
        //Player/Edit/{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = _db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        //POST: Edit
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Player player)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(player).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(player);
        }

        //GET: Details
        //Player/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Player player = _db.Players.Find(id);

            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }
    }
}