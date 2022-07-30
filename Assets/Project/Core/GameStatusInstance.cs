namespace Project.Core
{
    public class GameStatusInstance
    {
        private static GameStatus instance;
        public static GameStatus Instance => instance ??= new GameStatus();
        
        private GameStatusInstance()
        {
            
        }
    }
}