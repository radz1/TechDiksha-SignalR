using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class NotifyController : ApiController
    {
        private static readonly IHubContext context;

        static NotifyController()
        {
            context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
        }
        [HttpPost, Route("notify")]
        public IHttpActionResult NotifyAsync(SignalRNotification notification)
        {
            context.Clients.Group(notification.GroupId).ShowNotification(notification.SignalRMessage);
            return Ok();
        }
    }
}
