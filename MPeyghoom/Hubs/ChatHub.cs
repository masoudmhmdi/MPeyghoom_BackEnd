using Microsoft.AspNetCore.SignalR;

namespace MPeyghoom.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        
        public override async Task OnConnectedAsync()
        {
            var connectionId = Context.ConnectionId;
            var username = Context?.User?.Claims.FirstOrDefault(c => c.Type == "user")?.Value;

            // Add connection
            await Clients.Client(connectionId).SendAsync("ReceiveRegister", connectionId);
            await base.OnConnectedAsync();
        }
        
    }
}
