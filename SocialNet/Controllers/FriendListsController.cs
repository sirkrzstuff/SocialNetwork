using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SocialNet.Models;
using SocialNet.Service;
using SocialNet.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;

namespace SocialNet.Controllers
{
    public class FriendListsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //Connection for the viewmodels created
        ConnectionViewModel model = new ConnectionViewModel();

        //Service instances created
        UserService user_Service = new UserService();
        StatusService status_Service = new StatusService();
        FriendListService friend_Service = new FriendListService();
        GroupService group_Service = new GroupService();
        CommentService comment_Service = new CommentService();

        // GET: FriendLists
        [Authorize]
        public ActionResult Index()
        {
            //Instances filled with content
            model.ConnectionUsers = user_Service.GetAllUsers();
            model.ConnectionUserStatuses = status_Service.GetLatestStatuses();
            model.ConnectionFriendlist = friend_Service.GetAllFriends(this.User.Identity.Name);
            model.ConnectionGroups = group_Service.GetAllGroups();
            model.ConnectionComments = comment_Service.GetAllComments();

            //return the model with initialized content to be used in the views.
            return View(model);
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
        public ActionResult Create(FormCollection formData)
        {
            if (ModelState.IsValid)
            {
                model.ConnectionFriendlistForm = new FriendList
                {
                    Id = Convert.ToInt32(formData["ConnectionFriendlistForm.Id"]),
                    FriendName = formData["ConnectionFriendlistForm.FriendName"],
                    UserName = formData["ConnectionFriendlistForm.UserName"]
                };

                db.FriendLists.Add(model.ConnectionFriendlistForm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(formData);
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
        public ActionResult Edit([Bind(Include = "Id,UserName,FriendName,FriendIsTopFriend")] FriendList friendList)
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
            model.ConnectionUsers = user_Service.GetAllUsers();
            model.ConnectionUserStatuses = status_Service.GetLatestStatuses();
            model.ConnectionFriendlist = friend_Service.GetAllFriends(this.User.Identity.Name);
            model.ConnectionGroups = group_Service.GetAllGroups();
            return View(model);
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

        public ActionResult AddAsFriend(string friend)
        {
            //var currentUser = db.Users.FirstOrDefault(u => u.UserName == this.User.Identity.Name);
            //if (currentUser == null) return Json(new { Success = false });
            var addFriend = new FriendList
           {
               UserName = this.User.Identity.Name,
               FriendName = friend            
           };
  
            if (ModelState.IsValid)
            {
                db.FriendLists.Add(addFriend);
                db.SaveChanges();

                var friendSwitch = new FriendList
                {
                    UserName = friend,
                    FriendName = this.User.Identity.Name
                };

                if (ModelState.IsValid)
                {
                    db.FriendLists.Add(friendSwitch);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return View("SearchResults");
        }

        public ActionResult MyGroups()
        {
            //Instances filled with content
            model.ConnectionUsers = user_Service.GetAllUsers();
            model.ConnectionUserStatuses = status_Service.GetLatestStatuses();
            model.ConnectionFriendlist = friend_Service.GetAllFriends(this.User.Identity.Name);
            model.ConnectionGroups = group_Service.GetAllGroups();

            //return the model with initialized content to be used in the views.
            return View(model);
        }

        public ActionResult UsersOnline()
        {
            //Instances filled with content
            model.ConnectionUsers = user_Service.GetAllUsers();
            model.ConnectionUserStatuses = status_Service.GetLatestStatuses();
            model.ConnectionFriendlist = friend_Service.GetAllFriends(this.User.Identity.Name);
            model.ConnectionGroups = group_Service.GetAllGroups();

            //return the model with initialized content to be used in the views.
            return View(model);
        }

        //public JsonResult AddAsFriend([Required]User user)
        //{
        //    var currentUser = db.Users.FirstOrDefault(u => u.UserName == this.User.Identity.Name);
        //    if (currentUser == null) return Json(new { Success = false });

        //    currentUser.FriendList.Add(user);
        //    db.SaveChanges();
        //    return null;
        //}

    }
}
