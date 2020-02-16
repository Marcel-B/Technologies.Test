﻿using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Technology.Api
{
    public class MessageHub : Hub
    {
        public MessageHub() { }

        public async Task SendMessage(
            string user,
             string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
