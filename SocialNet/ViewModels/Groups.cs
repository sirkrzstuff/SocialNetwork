using SocialNet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace SocialNet.ViewModels
{
    public class Groups
    {
        public int Id { get; set; }
        public string CreatorName { get; set; }
        public string GroupName { get; set; }
        public DateTime? GroupDateCreated { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public Groups()
        {
            //UserName = Membership.GetUserNameByEmail();
            CreatorName = Author.UserName;
            GroupDateCreated = DateTime.Now;          
        }

    }
}