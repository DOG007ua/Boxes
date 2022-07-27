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
            var dataBorder = CalculationBorder();
            spawner = new Spawner(gameStatus, 
                new CreatorBots(dataBotsSpawn, gameStatus, dataBorder),
                new TypeSpawnUnitSystem(), dataBorder);
            gameController = new GameController(spawner, gameStatus);
        }

        private DataBorder CalculationBorder()
        {
            DataBorder dataBorder = new DataBorder();
            dataBorder.XLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
            dataBorder.XRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
            dataBorder.YMin = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
            dataBorder.YMax = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
            
            return dataBorder;
        }
    }
}