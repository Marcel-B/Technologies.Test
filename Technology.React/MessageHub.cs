using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Technology.React
{
    public class MessageHub : Hub
    {
        public Task SendMessage(
            string user,
            string message)
            => Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}
