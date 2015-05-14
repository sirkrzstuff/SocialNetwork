using SocialNet.Models;
using SocialNet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNet.Service
{
    public class MessengerService
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //private ApplicationDbContext db;

        public IEnumerable<Messenger> GetAllMesseges(string UserOne, string UserTwo)
        {
            var model = (from m in db.Messengers
                         orderby m.TimeSent descending
                         select m).ToList();
            return model;
        }
    }
}