using SocialNet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SocialNet.ViewModels
{
    public class Comment
    {
        public int CommentID { get; set; }
        public int? UserStatusID { get; set; }
        public string CommentBody { get; set; }
        public DateTime? CommentDate { get; set; }
        public string Author { get; set; }

        //public virtual ApplicationUser Author { get; set; }
        public virtual UserStatus UserStatus { get; set; }

        public Comment ()
        {
            CommentDate = DateTime.Now;
        }
    }
}