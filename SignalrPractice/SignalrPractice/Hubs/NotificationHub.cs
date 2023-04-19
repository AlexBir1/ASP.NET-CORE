using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalrPractice.Hubs
{
    public class NotificationHub : Hub
    {
        public Task SendMessage(string message)
        {
            var Result = CheckMessage(message);
            return Clients.Others.SendAsync("Send", Result);
        }

        string CheckMessage(string _message)
        {
            if (_message.Contains("fuck"))
                return "<forbidden_word>";
            return _message;
        }
    }
}
