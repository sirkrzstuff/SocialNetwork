using SocialNet.Models;
using SocialNet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNet.Service
{
    public class StatusService
    {
       
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<UserStatus> GetLatestForUser(string UserName)
        {

            var friends = new List<string>();

            /*var statuses = (from s in db.UserStatuses
                            where friends.Contains(s.UserName)
                            select s).ToList();*/

            return new List<UserStatus>();
        }

        public IEnumerable<UserStatus> GetLatestStatuses()
        {
            var model = (from r in db.UserStatuses
                         orderby r.StatusDate descending
                         select r).ToList();
            return model;
        }
    }
}