﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SocialNet.Hubs
{
    public class MessengerHub : Hub
    {
        public void send (string name, string message)
        {
            Clients.All.addNewMessageToPage(name, message);
        }

    }
}