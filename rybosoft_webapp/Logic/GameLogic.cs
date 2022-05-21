using rybosoft_webapp.Models;

namespace rybosoft_webapp.Logic
{
    public interface IGameLogic
    {
        void SaveMessage(string user, string message);
        List<Messages>? GetMessages(int top = 10);
    }

    public class GameLogic : IGameLogic
    {
        public List<Messages>? GetMessages(int top = 10)
        {
            var entity = new RyboDBContext();

            return entity.Messages?.Take(top).ToList();
        }

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
