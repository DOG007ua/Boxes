using Project.Core.Spawn;
using UnityEngine;

namespace Project.Core
{
    public class GameController
    {
        private GameStatus GameStatus { get; set; }
        private Spawner Spawner;

        public GameController(Spawner spawner, GameStatus gameStatus)
        {
            GameStatus = gameStatus;
            Spawner = spawner;
            Spawner.finishLevel += NextLevel;
        }

        private void NextLevel()
        {
            GameStatus.NextLevel();
            Spawner.NextLevel();
            Debug.Log($"Next Level {GameStatus.Level}");
        }
    }
}