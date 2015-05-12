using System;
using System.Linq;
using System.Web;
using SocialNet.Controllers;
using SocialNet.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace SocialNet.ViewModels
{
    public class UserStatus
    {
        public int Id { get; set; }
        public string StatusBody { get; set; }
        public DateTime? StatusDate { get; set; }

        public virtual ApplicationUser Author { get; set; }
        public virtual IList<Comment> Comments { get; set; }

        public UserStatus ()
        {
            StatusDate = DateTime.Now;
        }
    }
}