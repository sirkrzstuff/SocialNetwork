using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using System.Diagnostics;
using SocialNet.ViewModels;
using SocialNet.Models;
using System.Data.Entity;
using System.Collections.Concurrent;
using SocialNet.Service;


namespace SocialNet.Hubs
{
    //Much of the code is from: http://www.tugberkugurlu.com/archive/mapping-asp-net-signalr-connections-to-real-application-users
    //This hub is for SignalR functions
    [Authorize]
    public class MessengerHub : Hub
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        ConnectionViewModel model = new ConnectionViewModel();

        //Service instances created
        UserService user_Service = new UserService();

        private static readonly ConcurrentDictionary<string, User> Users
        = new ConcurrentDictionary<string, User>();

        public void send(string name, string message)
        {
            string sendName = Context.User.Identity.Name;
            Clients.All.addNewMessageToPage(name, sendName + ": " + message);
        }

        public void send(string message)
        {
            string name = Context.User.Identity.Name;
            Clients.All.addNewMessage(name + ": " + message);
        }

        //public Task Join()
        //{
        //    return Groups.Add(Context.ConnectionId, "foo");
        //}

        //public Task Send(string message)
        //{

        //    return Clients.Group("foo").addMessage(message);
        //}


        public override Task OnConnected()
        {

            string userName = Context.User.Identity.Name;
            string connectionId = Context.ConnectionId;

            var user = Users.GetOrAdd(userName, _ => new User
            {
                UserName = userName,
                ConnectionIds = new HashSet<string>()
            });

            lock (user.ConnectionIds)
            {

                user.ConnectionIds.Add(connectionId);

                 //TODO: Broadcast the connected user
                if (user.ConnectionIds.Count == 1)
                {

                    Clients.Others.userConnected(userName);
                }
            }

            Clients.AllExcept(user.ConnectionIds.ToArray()).userConnected(userName);

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {

            string userName = Context.User.Identity.Name;
            string connectionId = Context.ConnectionId;

            User user;
            Users.TryGetValue(userName, out user);

            if (user != null)
            {

                lock (user.ConnectionIds)
                {

                    user.ConnectionIds.RemoveWhere(cid => cid.Equals(connectionId));

                    if (!user.ConnectionIds.Any())
                    {

                        User removedUser;
                        Users.TryRemove(userName, out removedUser);

                        // You might want to only broadcast this info if this 
                        // is the last connection of the user and the user actual is 
                        // now disconnected from all connections.
                        Clients.Others.userDisconnected(userName);
                    }
                }
            }

            return base.OnDisconnected(stopCalled);
        }

        //public void Send(string message)
        //{

        //    string sender = Context.User.Identity.Name;

        //    Clients.All.received(new
        //    {
        //        sender = sender,
        //        message = message,
        //        isPrivate = false
        //    });
        //}

        //public void Send(string message, string to)
        //{

        //    User receiver;
        //    if (Users.TryGetValue(to, out receiver))
        //    {

        //        User sender = GetUser(Context.User.Identity.Name);

        //        IEnumerable<string> allReceivers;
        //        lock (receiver.ConnectionIds)
        //        {
        //            lock (sender.ConnectionIds)
        //            {

        //                allReceivers = receiver.ConnectionIds.Concat(
        //                    sender.ConnectionIds);
        //            }
        //        }

        //        foreach (var cid in allReceivers)
        //        {

        //            Clients.Client(cid).received(new
        //            {
        //                sender = sender.UserName,
        //                message = message,
        //                isPrivate = true
        //            });
        //        }
        //    }
        //}

        private User GetUser(string username)
        {

            User user;
            Users.TryGetValue(username, out user);

            return user;
        }
    }
}