using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;
using System;
using System.Web.Http;

[assembly: OwinStartup(typeof(WebApplication1.startup))]
namespace WebApplication1
{
    public class startup
    {
        public void Configuration(IAppBuilder app)
        {
            var configuration = new HttpConfiguration();
            var jsonFormatter = configuration.Formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;

            GlobalHost.Configuration.ConnectionTimeout = TimeSpan.FromSeconds(110);
            GlobalHost.Configuration.DisconnectTimeout = TimeSpan.FromSeconds(30);
            GlobalHost.Configuration.KeepAlive = TimeSpan.FromSeconds(10);//Should be 1/3 of DisconnectTimeout
            //GlobalHost.DependencyResolver.UseServiceBus(ConfigurationManager.AppSettings["ServiceBusConnectionString"], "DigitalNotifications");
            
            app.Map("/signalr", map =>
            {               
                var hubConfiguration = new HubConfiguration
                {
                    // You can enable JSONP by uncommenting line below.
                    // JSONP requests are insecure but some older browsers (and some
                    // versions of IE) require JSONP to work cross domain
                    EnableJSONP = true,
                    EnableDetailedErrors = true,
                    EnableJavaScriptProxies = true
                };
                // Run the SignalR pipeline. We're not using MapSignalR
                // since this branch already runs under the "/signalr"
                // path.
                map.RunSignalR(hubConfiguration);
            });
        }
    }
}