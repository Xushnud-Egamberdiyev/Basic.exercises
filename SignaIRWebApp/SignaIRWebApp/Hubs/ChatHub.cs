using Microsoft.AspNetCore.SignalR;

namespace SignaIRWebApp.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessageToAll(string user, string message) =>
            await Clients.All.SendAsync("ReceiveMessage", Context.ConnectionId, message);

        public async Task SendMessageToCaller(string user, string message) =>
            await Clients.Caller.SendAsync("ReceiveMessage", Context.ConnectionId, message);

        public async Task SendMessageToUser(string user, string message, string connectionId) =>
            await Clients.Client(connectionId).SendAsync("ReceiveMessage", Context.ConnectionId, message);

        public async Task SendMessageToGroup(string user, string message) =>
           await Clients.Group("SignalR Users").SendAsync("ReceiveMessage", Context.ConnectionId, message);

    }
}
