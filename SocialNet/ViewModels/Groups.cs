using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialNet.ViewModels
{
    public class Groups
    {
        [Key]
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public DateTime? GroupDateCreated { get; set; }

        public string UserName { get; set; }

        public Groups()
        {
            GroupDateCreated = DateTime.Now;
        }
    }
}