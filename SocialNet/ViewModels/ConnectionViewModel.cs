using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNet.ViewModels
{
    public class ConnectionViewModel
    {
        public IEnumerable<User> ConnectionUsers { get; set; }
        public User ConnectionUserForm { get; set; }
        public IEnumerable<UserStatus> ConnectionUserStatuses { get; set; }
        public IEnumerable<Comment> ConnectionComments { get; set; }
        public SearchBar ConnectionSearchbar { get; set; }
        public SearchResults ConnectionSearchresults { get; set; }
        public IEnumerable<FriendList> ConnectionFriendlist { get; set; }
        public FriendList ConnectionFriendlistForm { get; set; }
        public IEnumerable<Groups> ConnectionGroups { get; set; }
        public Groups ConnectionGroupsForm { get; set; }
        public Groups ConnectionGroupsById { get; set; }
    }
}