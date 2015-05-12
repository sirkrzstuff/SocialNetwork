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
using System.ComponentModel.DataAnnotations;

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
        public ActionResult Create([Bind(Include = "Id,UserId,FriendId,FriendIsTopFriend")] FriendList friendList)
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
        public ActionResult Edit([Bind(Include = "Id,UserId,FriendId,FriendIsTopFriend")] FriendList friendList)
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

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(SearchBar searchBar)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("SearchResults", new { searchString = searchBar.SearchString });
            }
            return RedirectToAction("Index");
        }

        public ActionResult SearchResults(string searchString)
        {
            var split = searchString.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var users = db.Users.Where(u => split.Contains(u.FirstName.ToLower()) || split.Contains(u.LastName.ToLower()));
            var personas = db.Personas.Where(u => split.Contains(u.Name.ToLower()));
            var results = new SearchResults { SearchString = searchString, Users = users.ToList(), Personas = personas.ToList() };
            return View(results);
        }

        public JsonResult AddAsFriend([Required]User user)
        {
            var currentUser = db.Users.FirstOrDefault(u => u.UserName == this.User.Identity.Name);
            if (currentUser == null) return Json(new { Success = false });

            currentUser.FriendList.Add(user);
            return null;
        }

    }
}
