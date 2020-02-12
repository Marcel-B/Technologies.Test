using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Technology.React
{
    public class MessageHub : Hub
    {
        public async Task SendMessage(
            string user,
            string message)
            => await Clients.All.SendAsync("ReceiveMessage", user, message);

        public override async Task OnConnectedAsync()
        {
            System.Console.WriteLine("Client connected");
            await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnConnectedAsync();
        }
    }
}
