using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChatService.Data;
using ChatService.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace ChatService.Controllers
{
    [HubName("myHub")]
    public class MyHub : Hub
    {
        static List<User> ConnectedUser = new List<User>();
        ApplicationDbContext db = new ApplicationDbContext();
        public void Connect(string name)
        {
            User user = new User
            {
                ConnectionTime = DateTime.Now.ToString(),
                ConnectionId = Context.ConnectionId,
                Name = name
            };
            ConnectedUser.Add(user);
            db.Users.Add(user);
            db.SaveChanges();
            Clients.Others.ReceivedMessage("New User", name);
            Clients.Caller.ReceivedMessage("Me", name);
        }

        public void Send(string msg)
        {
            var uid = db.Users.Where(u => u.ConnectionId == Context.ConnectionId).SingleOrDefault().Id;
            var uname = ConnectedUser.SingleOrDefault(n => n.ConnectionId == Context.ConnectionId).Name;

            Message message = new Message
            {
                Text = msg,
                ConnectionTime = DateTime.Now.ToString(),
                ConnectionId = uid
            };
            db.Messages.Add(message);
            db.SaveChanges();
            Clients.Others.ReceivedMessage(uname, msg);
            Clients.Caller.ReceivedMessage("Me", msg);
        }
    }
}