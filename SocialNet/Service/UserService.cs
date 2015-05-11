using Microsoft.AspNet.Identity.EntityFramework;
using SocialNet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNet.Service
{
    public class UserService
    {
        public IEnumerable<User> GetAllUsers()
        {
            var model = new List<User>();
            using (var context = new IdentityDbContext())
            {
                model =
                    context.Users.Select(u =>
                        new User
                        {
                            UserName = u.UserName
                        }).ToList();
            }

            return model;
        }
    }
}