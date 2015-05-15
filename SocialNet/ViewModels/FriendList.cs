using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace SocialNet.ViewModels
{
    public class FriendList
    {
        
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FriendName { get; set; }
        public bool? FriendIsTopFriend { get; set; }

        public FriendStatus FriendStatus { get; set; }
        public virtual User User { get; set; }

    }

    public enum FriendStatus
    {
        Active,
        Pending
    }

    
}