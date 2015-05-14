using SocialNet.Models;
using SocialNet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNet.Service
{
    public class GroupService
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //private ApplicationDbContext db;
        public IEnumerable<Groups> GetAllGroups()
        {
            var model = (from groups in db.GroupsList
                         orderby groups.Id ascending
                         select groups).ToList();
            return model;
        }
    }
}