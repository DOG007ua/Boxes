using System;
using Project.Core.Input;
using Project.Core.Spawn;
using Project.Game.Scripts.UnitFolder;
using Project.Game.Scripts.UnitFolder.Shoot;
using Project.Game.Scripts.UnitFolder.Spawn;
using UnityEngine;

namespace Project.Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private DataBotsSpawn dataBotsSpawn;
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private ListGuns listGuns;
        private Spawner spawner;
        private GameController gameController;
            
        
        
        private void Start()
        {
            var dataBorder = CalculationBorder();
            CreateSpawner(dataBorder);
            gameController = new GameController(spawner);
            gameObject.AddComponent<InputController>().Init(new InputControllerPlayerKey(spawner.Player.ControlerUnit));
        }

        private void CreateSpawner(DataBorder dataBorder)
        {
            var creatorBots = new CreatorBots(dataBotsSpawn, dataBorder);
            var creatorPlayer = new CreatorPlayer(playerPrefab, dataBorder, listGuns);
            spawner = new Spawner( 
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