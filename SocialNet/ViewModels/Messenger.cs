using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNet.ViewModels
{
    public class Messenger
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string MessageBody { get; set; }
        public DateTime? TimeSent { get; set; }
        public bool Connected { get; set; }

        public Messenger()
        {
            TimeSent = DateTime.Now;
        }
    }
}