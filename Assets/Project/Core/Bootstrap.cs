using System;
using Project.Core.Spawn;
using UnityEngine;

namespace Project.Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private DataBotsSpawn dataBotsSpawn;
        private Spawner spawner;
        private GameController gameController;
        
        
        private void Start()
        {
            var gameStatus = new GameStatus();
            spawner = new Spawner(gameStatus, 
                new CreatorBots(dataBotsSpawn, gameStatus),
                new TypeSpawnUnitSystem() );
            gameController = new GameController(spawner, gameStatus);
        }
    }
}