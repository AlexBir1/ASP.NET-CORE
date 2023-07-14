using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleMessenger.Hubs
{
    public class ChattingHub : Hub
    {
        public async Task SendMessage(string chatId, string fromUser, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", chatId, fromUser, message);
        }
    }
}
