using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Technology.Pages
{
    public class MessageHub : Hub
    {
        public MessageHub()
        {
        }

        public async Task SendMessage(
            string user,
             string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
