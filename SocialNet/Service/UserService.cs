using Microsoft.AspNet.Identity.EntityFramework;
using SocialNet.Models;
using SocialNet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNet.Service
{
    public class UserService
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //public IEnumerable<User> GetAllUsers()
        //{
        //    var model = new List<User>();
        //    using (var context = new IdentityDbContext())
        //    {
        //        model =
        //            context.Users.Select(u =>
        //                new User
        //                {
        //                    UserName = u.UserName
        //                }).ToList();
        //    }

        //    return model;
        //}

        public IEnumerable<User> GetAllUsers()
        {
            var model = (from usr in db.Users
                         orderby usr.FirstName ascending
                         select usr).ToList();
            return model;
        }

        public void SaveUser()
        {

        }
    }
}