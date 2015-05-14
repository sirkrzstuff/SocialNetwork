using System;
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
            //Instances filled with content
            model.ConnectionUsers = user_Service.GetAllUsers();
            model.ConnectionUserStatuses = status_Service.GetLatestStatuses();
            model.ConnectionFriendlist = friend_Service.GetAllFriends(this.User.Identity.Name);
            model.ConnectionGroups = group_Service.GetAllGroups();

            if (id == null)
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
            return View();
        }
    }
}