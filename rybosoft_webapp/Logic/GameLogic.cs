using rybosoft_webapp.Models;

namespace rybosoft_webapp.Logic
{
    public interface IGameLogic
    {
        void SaveMessage(string user, string message);
    }

    public class GameLogic : IGameLogic
    {
        public void SaveMessage(string user, string message)
        {
            var entity = new RyboDBContext();
            
            var messageObj = new Messages()
            {
                UserId = user,
                MessageText = message
            };

            entity.Messages?.Add(messageObj);
            entity.SaveChanges();
        }
    }
}
