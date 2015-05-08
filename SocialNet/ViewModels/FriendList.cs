using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialNet.ViewModels
{
    public class FriendList
    {
        [Key]
        public int FriendID { get; set; }
        public string FriendName { get; set; }
        public bool FriendIsTopFriend { get; set; }

        public string UserName { get; set; }
    }
}