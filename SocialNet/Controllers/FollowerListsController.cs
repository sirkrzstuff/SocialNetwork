using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SocialNet.Models;
using SocialNet.ViewModels;

namespace SocialNet.Controllers
{
    public class FollowerListsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FollowerLists
        public ActionResult Index()
        {
            return View(db.FollowerLists.ToList());
        }

        // GET: FollowerLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FollowerList followerList = db.FollowerLists.Find(id);
            if (followerList == null)
            {
                return HttpNotFound();
            }
            return View(followerList);
        }

        // GET: FollowerLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FollowerLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FollowerID,FollowerName")] FollowerList followerList)
        {
            if (ModelState.IsValid)
            {
                db.FollowerLists.Add(followerList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(followerList);
        }

        // GET: FollowerLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FollowerList followerList = db.FollowerLists.Find(id);
            if (followerList == null)
            {
                return HttpNotFound();
            }
            return View(followerList);
        }

        // POST: FollowerLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FollowerID,FollowerName")] FollowerList followerList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(followerList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(followerList);
        }

        // GET: FollowerLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FollowerList followerList = db.FollowerLists.Find(id);
            if (followerList == null)
            {
                return HttpNotFound();
            }
            return View(followerList);
        }

        // POST: FollowerLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FollowerList followerList = db.FollowerLists.Find(id);
            db.FollowerLists.Remove(followerList);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
