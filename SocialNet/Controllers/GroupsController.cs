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
    public class GroupsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //Connection for the viewmodels created
        ConnectionViewModel model = new ConnectionViewModel();

        //Service instances created
        UserService user_service = new UserService();
        StatusService status_service = new StatusService();
        FriendListService friend_service = new FriendListService();
        GroupService group_service = new GroupService();

        // GET: Groups
        [Authorize]
        public ActionResult Index()
        {

            //Instances filled with content
            model.cn_users = user_service.GetAllUsers();
            model.cn_userstatuses = status_service.GetLatestStatuses();
            model.cn_friendlist = friend_service.GetAllFriends();
            model.cn_groups = group_service.GetAllGroups();

            //return the model with initialized content to be used in the views.
            return View(model);
        }

        // GET: Groups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Groups groups = db.GroupsList.Find(id);
            if (groups == null)
            {
                return HttpNotFound();
            }
            return View(groups);
        }

        // GET: Groups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection form)
        {
            if (ModelState.IsValid)
            {
                model.cn_groups_form = new Groups
                {
                    Id = Convert.ToInt32(form["cn_groups_form.Id"]),
                    CreatorName = form["cn_groups_form.CreatorName"],
                    GroupName = form["cn_groups_form.GroupName"]
                };

                db.GroupsList.Add(model.cn_groups_form);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(form);
        }

        // GET: Groups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Groups groups = db.GroupsList.Find(id);
            if (groups == null)
            {
                return HttpNotFound();
            }
            return View(groups);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupID,CreatorId,GroupName,GroupDateCreated")] Groups groups)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groups).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(groups);
        }

        // GET: Groups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Groups groups = db.GroupsList.Find(id);
            if (groups == null)
            {
                return HttpNotFound();
            }
            return View(groups);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Groups groups = db.GroupsList.Find(id);
            db.GroupsList.Remove(groups);
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

        public ActionResult GroupProfile()
        {
            //Instances filled with content
            model.cn_users = user_service.GetAllUsers();
            model.cn_userstatuses = status_service.GetLatestStatuses();
            model.cn_friendlist = friend_service.GetAllFriends();
            model.cn_groups = group_service.GetAllGroups();

            //return the model with initialized content to be used in the views.
            return View(model);
        }
    }
}
