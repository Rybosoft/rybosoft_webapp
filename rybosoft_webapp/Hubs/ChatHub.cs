using Microsoft.AspNetCore.SignalR;
using rybosoft_webapp.Logic;
using rybosoft_webapp.Models;

namespace rybosoft_webapp.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IGameLogic _gameLogic;

        public ChatHub(IGameLogic gameLogic)
        {
            _gameLogic = gameLogic;
        }

        public List<Messages>? GetLastMessages(int top)
        {
            return _gameLogic.GetMessages(top);
        }

        public async Task SendMessage(string user, string message)
        {
            // Send message to all clients
            await Clients.All.SendAsync("ReceiveMessage", user, message);

            // Save message in DB to keep messages history
            _gameLogic.SaveMessage(user, message);
        }
    }
}
