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

namespace SocialNet.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //Connection for the viewmodels created
        ConnectionViewModel model = new ConnectionViewModel();

        //Service instances created
        UserService user_service = new UserService();
        StatusService status_service = new StatusService();
        FriendListService friend_service = new FriendListService();
        GroupService group_service = new GroupService();

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
        public ActionResult Profile()
        {
            //Instances filled with content
            model.cn_users = user_service.GetAllUsers();
            model.cn_userstatuses = status_service.GetLatestStatuses();
            model.cn_friendlist = friend_service.GetAllFriends();
            model.cn_groups = group_service.GetAllGroups();

            //return the model with initialized content to be used in the views.
            return View(model);
        }

        [Authorize]
        public ActionResult RightBar()
        {
            return View();
        }

        [Authorize]
        public ActionResult ProfileBar()
        {
            return View();
        }

    }
}