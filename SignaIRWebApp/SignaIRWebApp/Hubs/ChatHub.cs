using Microsoft.AspNetCore.SignalR;

namespace SignaIRWebApp.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessageToAll(string user, string message) =>

        public async Task SendMessageToCaller(string user, string message) =>


        public async Task SendMessageToGroup(string user, string message) =>

    }
}
