using System;
using Project.Core.Input;
using Project.Core.Spawn;
using Project.Game.Scripts.UnitFolder;
using UnityEngine;

namespace Project.Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private DataBotsSpawn dataBotsSpawn;
        [SerializeField] private GameObject playerPrefab;
        private Spawner spawner;
        private GameController gameController;
            
        
        
        private void Start()
        {
            var gameStatus = new GameStatus();
            var dataBorder = CalculationBorder();
            CreateSpawner(gameStatus, dataBorder);
            gameController = new GameController(spawner, gameStatus);
            gameObject.AddComponent<InputController>().Init(new InputControllerPlayerKey(spawner.Player.ControlerUnit));
        }

        private void CreateSpawner(GameStatus gameStatus, DataBorder dataBorder)
        {
            var creatorBots = new CreatorBots(dataBotsSpawn, gameStatus, dataBorder);
            var creatorPlayer = new CreatorPlayer(playerPrefab, gameStatus, dataBorder);
            spawner = new Spawner(gameStatus, 
                creatorBots,
                creatorPlayer, 
            new TypeSpawnUnitSystem(), dataBorder);
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