using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialNet.ViewModels
{
    public class FollowerList
    {   
        [Key]
        public int FollowerID { get; set; }
        public string FollowerName { get; set; }

        public string UserName { get; set; }
    }
}