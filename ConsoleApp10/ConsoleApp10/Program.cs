using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class Program
    {
        static HubConnection hubConnection;

        static async Task Main(string[] args)
        {
            hubConnection = new HubConnectionBuilder().WithUrl("https://localhost:44313/notification").Build();
            Console.WriteLine("Hello World!");

            hubConnection.On<string>("Send", message => Console.WriteLine($"Msg: {message}"));
            await hubConnection.StartAsync();
            bool isExit = false;

            while (!isExit)
            {
                var message = Console.ReadLine();
                if (message != "exit")
                {
                    await hubConnection.SendAsync("SendMessage", message);
                }
                else
                    isExit = true;
            }
            Console.ReadLine();
        }
    }
}
