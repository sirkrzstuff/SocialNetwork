using SocialNet.Models;
using SocialNet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNet.Service
{
    public class CommentService
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //private ApplicationDbContext db;

        public IEnumerable<Comment>GetAllComments()
        {

            var model = (from r in db.Comments
                         orderby r.CommentDate descending
                         select r).ToList();
            return model;

            //var friends = new List<string>();

            //var statuses = (from s in db.UserStatuses
            //                where friends.Contains(s.UserName)
            //                select s).ToList();

            //return new List<Comment>();
        }

        //public IEnumerable<Comment> GetComments()
        //{
        //    var model = (from r in db.UserStatuses
        //                 orderby r.StatusDate descending
        //                 select r).ToList();
        //    return model;
        //}
    }
}