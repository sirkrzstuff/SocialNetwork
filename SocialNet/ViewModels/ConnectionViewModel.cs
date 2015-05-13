using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNet.ViewModels
{
    public class ConnectionViewModel
    {
        public IEnumerable<User> cn_users { get; set; }
        public User cn_user_form { get; set; }
        public IEnumerable<UserStatus> cn_userstatuses { get; set; }
        public SearchBar cn_searchbar { get; set; }
        public SearchResults cn_searchresults { get; set; }
        public IEnumerable<FriendList> cn_friendlist { get; set; }
        public FriendList cn_friendlist_form { get; set; }
        public IEnumerable<Groups> cn_groups { get; set; }
        public Groups cn_groups_form { get; set; }
        public Groups cn_group_byID { get; set; }
    }
}