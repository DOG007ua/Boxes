using Project.Core.Spawn;
using UnityEngine;

namespace Project.Core
{
    public class GameController
    {
        private Spawner Spawner;

        public GameController(Spawner spawner)
        {
            Spawner = spawner;
            Spawner.finishLevel += NextLevel;
        }

        private void NextLevel()
        {
            GameStatusInstance.Instance.NextLevel();
            Spawner.NextLevel();
            Debug.Log($"Next Level {GameStatusInstance.Instance.Level}");
        }
    }
}