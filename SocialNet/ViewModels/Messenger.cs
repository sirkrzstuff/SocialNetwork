using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNet.ViewModels
{
    public class Messenger
    {
        public int Id { get; set; }
        public string UserOne { get; set; }
        public string UserTwo { get; set; }
        public string MessageBody { get; set; }
        public DateTime? TimeSent { get; set; }

        public Messenger()
        {
            TimeSent = DateTime.Now;
        }
    }
}