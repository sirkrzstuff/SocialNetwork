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
       
        public List<UserStatus> GetLatestForUser(string UserName)
        {
            var db = new ApplicationDbContext();

            var friends = new List<string>();

            /*var statuses = (from s in db.UserStatuses
                            where friends.Contains(s.UserName)
                            select s).ToList();*/

            return new List<UserStatus>();
        }
    }
}