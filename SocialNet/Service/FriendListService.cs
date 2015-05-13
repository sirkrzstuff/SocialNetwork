﻿using SocialNet.ViewModels;
using SocialNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace SocialNet.Service
{
    public class FriendListService
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IEnumerable<FriendList> GetAllFriends()
        {
            var model = (from friend in db.FriendLists
                         orderby friend.FriendName
                         select friend).ToList();
            return model;
        }
    }
}