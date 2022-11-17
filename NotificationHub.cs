using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace BBService.MyClasses
{
    public class NotificationHub : Hub
    {
        private readonly Dictionary<string, string> lstAllConnections;
        private readonly Dictionary<string, string> lstAllConnectedUsers;
        private readonly NotificationComponents notificationComponents;

        public NotificationHub()
        {
            lstAllConnections = new Dictionary<string, string>();
            lstAllConnectedUsers = new Dictionary<string, string>();
            notificationComponents = new NotificationComponents();
        }

        public override Task OnConnected()
        {
            lstAllConnections.Add(Context.ConnectionId, "");
            Clients.All.BroadcastConnections(lstAllConnections);

            string userConnectionId = Context.ConnectionId;
            string userId = Context.QueryString["myUserId"].ToString();
            if (!lstAllConnectedUsers.Keys.Contains(userId))
            {
                lstAllConnectedUsers.Add(userId, userConnectionId);
            }

            return base.OnConnected();
        }


        public override Task OnDisconnected(bool stopCalled)
        {
            lstAllConnections.Remove(Context.ConnectionId);
            Clients.All.BroadcastConnections(lstAllConnections);

            string userId = Context.QueryString["myUserId"].ToString();
            if (lstAllConnectedUsers.Keys.Contains(userId))
            {
                lstAllConnectedUsers.Remove(userId);
            }

            return base.OnDisconnected(stopCalled);
        }

        public Dictionary<string, string> GetLstAllConnectedUsers()
        {
            return lstAllConnectedUsers;
        }
    }
}