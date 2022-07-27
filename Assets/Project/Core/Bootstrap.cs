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
                new TypeSpawnUnitSystem(), CalculationPositions());
            gameController = new GameController(spawner, gameStatus);
        }

        private DataPositions CalculationPositions()
        {
            DataPositions dataPositions = new DataPositions();
            dataPositions.XLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
            dataPositions.XRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
            dataPositions.YMin = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
            dataPositions.YMax = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
            
            Debug.Log($"XRight {dataPositions.XRight}");
            Debug.Log($"XLeft {dataPositions.XLeft}");
            Debug.Log($"YMax {dataPositions.YMax}");
            Debug.Log($"YMin {dataPositions.YMin}");
            return dataPositions;
        }
    }
}