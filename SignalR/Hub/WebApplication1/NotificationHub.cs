using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1
{
    public class NotificationHub : Hub
    {      
        public Task Register(string clientID)
        {
            return Groups.Add(Context.ConnectionId, clientID);
        }

        /// <summary>
        /// Deregisters the specified hud identifier.
        /// </summary>
        /// <param name="hudId">The hud identifier.</param>
        /// <returns></returns>
        public Task Deregister(string clientID)
        {
            return Groups.Remove(Context.ConnectionId, clientID);
        }
    }
}