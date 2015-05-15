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
using SocialNet.Service;

namespace SocialNet.Controllers
{
    public class UserStatusController : Controller
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

        // GET: UserStatus
        public ActionResult Index()
        {
            //Instances filled with content
            model.ConnectionUsers = user_Service.GetAllUsers();
            model.ConnectionUserStatuses = status_Service.GetLatestStatuses();
            model.ConnectionFriendlist = friend_Service.GetAllFriends(this.User.Identity.Name);
            model.ConnectionGroups = group_Service.GetAllGroups();
            model.ConnectionComments = comment_Service.GetAllComments();

            return View(db.UserStatuses.ToList());
        }

        // GET: UserStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserStatus userStatus = db.UserStatuses.Find(id);
            if (userStatus == null)
            {
                return HttpNotFound();
            }
            return View(userStatus);
        }

        // GET: UserStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StatusBody,StatusDate")] UserStatus userStatus)
        {
            if (ModelState.IsValid)
            {
                //Creates a new comment section for the status
                //Comment newComment = new Comment();
                //newComment.UserStatusId = userStatus.Id;
                //db.Comments.Add(newComment);
                //db.SaveChanges();

                userStatus.Author = this.User.Identity.Name;
                db.UserStatuses.Add(userStatus);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(userStatus);
        }

        // GET: UserStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserStatus userStatus = db.UserStatuses.Find(id);
            if (userStatus == null)
            {
                return HttpNotFound();
            }
            return View(userStatus);
        }

        // POST: UserStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StatusBody,StatusDate")] UserStatus userStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userStatus);
        }

        // GET: UserStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserStatus userStatus = db.UserStatuses.Find(id);
            if (userStatus == null)
            {
                return HttpNotFound();
            }
            return View(userStatus);
        }

        // POST: UserStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserStatus userStatus = db.UserStatuses.Find(id);
            db.UserStatuses.Remove(userStatus);
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

        public ActionResult Wall()
        {
            var model = (from data in db.UserStatuses
                         orderby data.ID descending
                         select data).ToList();

            return View(model);
        }     

        //public ActionResult AddComment(int userStatusId, string commentBody)
        //{
            
        //    var newComment = new Comment
        //    {
        //        Author = this.User.Identity.Name,
        //        UserStatusId = 0,
        //        CommentBody = commentBody
        //    };

        //    if (ModelState.IsValid)
        //    {
        //        db.Comments.Add(newComment);
        //        db.SaveChanges(); 
        //    }

        //    return RedirectToAction("Index", "Home");
        //}
    }
}
