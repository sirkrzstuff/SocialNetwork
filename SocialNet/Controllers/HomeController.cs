﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocialNet.ViewModels;
using SocialNet.Models;
using SocialNet.Service;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using System.Web.UI.WebControls;
using System.Net;
using System.Data.Entity;

namespace SocialNet.Controllers
{
    public class HomeController : Controller
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
        PhotoService photo_Service = new PhotoService();

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

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public ActionResult Profile(int? id)
        {
            if(id != null)
            {
                model.ConnectionUsers = user_Service.GetAllUsers();
                model.ConnectionUserStatuses = status_Service.GetLatestStatuses();
                model.ConnectionFriendlist = friend_Service.GetAllFriends(this.User.Identity.Name);
                model.ConnectionGroups = group_Service.GetAllGroups();
                model.ConnectionComments = comment_Service.GetAllComments();
                model.ConnectionUserForm = user_Service.GetUserById(id);
            }
            else if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Profile profiles = db.Profiles.Find(id);
            if (profiles == null)
            {
                return HttpNotFound();
            }
            return View("Profile", model);
        }

        [Authorize]
        public ActionResult RightBar()
        {
            //Instances filled with content
            model.ConnectionUsers = user_Service.GetAllUsers();
            model.ConnectionUserStatuses = status_Service.GetLatestStatuses();
            model.ConnectionFriendlist = friend_Service.GetAllFriends(this.User.Identity.Name);
            model.ConnectionGroups = group_Service.GetAllGroups();

            //return the model with initialized content to be used in the views.
            return View(model);
        }

        [Authorize]
        public ActionResult ProfileBar()
        {
            model.ConnectionFriendlist = friend_Service.GetAllFriends(this.User.Identity.Name);
            return View("Profile", model);
        }

        public ActionResult ProfilePhotos(int id)
        {
            model.ConnectionUsers = user_Service.GetAllUsers();
            model.ConnectionUserStatuses = status_Service.GetLatestStatuses();
            model.ConnectionFriendlist = friend_Service.GetAllFriends(this.User.Identity.Name);
            model.ConnectionGroups = group_Service.GetAllGroups();
            model.ConnectionPhotos = photo_Service.GetPhotosFromUserId(id);
            model.ConnectionUserForm = user_Service.GetUserById(id);

            return View("ProfilePhotos", model);
        }

        public ActionResult Photos(int id)
        {
            model.ConnectionUsers = user_Service.GetAllUsers();
            model.ConnectionUserStatuses = status_Service.GetLatestStatuses();
            model.ConnectionFriendlist = friend_Service.GetAllFriends(this.User.Identity.Name);
            model.ConnectionGroups = group_Service.GetAllGroups();
            model.ConnectionPhotos = photo_Service.GetAllPhotos();

            return View("Photos", model);
        }

        public ActionResult Chat()
        {
            return View();
        }

        public ActionResult Messenger()
        {
            return View();
        }

       
        public ActionResult FriendList(int id)
        {
            model.ConnectionGroups = group_Service.GetAllGroups();
            model.ConnectionFriendlist = friend_Service.GetAllFriendsByUserId(id);
            model.ConnectionUserForm = user_Service.GetUserById(id);

            return View("FriendList", model);
        }

        public ActionResult EditProfile(int id)
        {
            model.ConnectionGroups = group_Service.GetAllGroups();
            model.ConnectionUserForm = user_Service.GetUserById(id);
            return View("EditProfile", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile(FormCollection form)
        {
            if (ModelState.IsValid)
            {
                var user = user_Service.GetUserByEmail(form["ConnectionUserForm.UserName"]);
                model.ConnectionUserForm = new User
                {
                    Id = user.Id,
                    DateOfBirth = Convert.ToDateTime(form["ConnectionUserForm.DateOfBirth"]),
                    FirstName = form["ConnectionUserForm.FirstName"],
                    LastName = form["ConnectionUserForm.LastName"],
                    AboutUser = form["ConnectionUserForm.AboutUser"],
                    IsMale = Convert.ToBoolean(form["ConnectionUserForm.IsMale"]),
                    IsSingle = Convert.ToBoolean(form["ConnectionUserForm.IsSingle"]),
                    UserName = form["ConnectionUserForm.UserName"]
                };

                db.Entry(model.ConnectionUserForm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Profile", new { id = model.ConnectionUserForm.Id });
            }

            return View(form);
        }

        public ActionResult AddAsFriend(string username)
        {
            FriendListsController ctrl = new FriendListsController();
            return ctrl.AddAsFriend(username);
        }
    }
}