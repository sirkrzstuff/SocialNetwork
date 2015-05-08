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
    public class FriendListsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FriendLists
        public ActionResult Index()
        {
            return View(db.FriendLists.ToList());
        }

        // GET: FriendLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FriendList friendList = db.FriendLists.Find(id);
            if (friendList == null)
            {
                return HttpNotFound();
            }
            return View(friendList);
        }

        // GET: FriendLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FriendLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FriendID,FriendName,FriendIsTopFriend")] FriendList friendList)
        {
            if (ModelState.IsValid)
            {
                db.FriendLists.Add(friendList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(friendList);
        }

        // GET: FriendLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FriendList friendList = db.FriendLists.Find(id);
            if (friendList == null)
            {
                return HttpNotFound();
            }
            return View(friendList);
        }

        // POST: FriendLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FriendID,FriendName,FriendIsTopFriend")] FriendList friendList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(friendList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(friendList);
        }

        // GET: FriendLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FriendList friendList = db.FriendLists.Find(id);
            if (friendList == null)
            {
                return HttpNotFound();
            }
            return View(friendList);
        }

        // POST: FriendLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FriendList friendList = db.FriendLists.Find(id);
            db.FriendLists.Remove(friendList);
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
