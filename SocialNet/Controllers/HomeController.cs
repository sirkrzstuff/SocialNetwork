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
        [Authorize]
        public ActionResult Index()
        {
           //Code for Status updates
            StatusService service = new StatusService();

            var statuses = service.GetLatestForUser(this.User.Identity.Name);

            var model = db.UserStatuses.ToList();

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
            var model = db.UserStatuses.ToList();
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