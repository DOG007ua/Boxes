using Project.Game.Scripts.UnitFolder;
using UnityEngine;

namespace Project.Core.Spawn
{
    public class CreatorPlayer : IProduct
    {
        private GameObject playerPrefab;
        private GameStatus gameStatus;
        private DataBorder dataBorder;

        public CreatorPlayer(GameObject playerPrefab, GameStatus gameStatus, DataBorder dataBorder)
        {
            this.playerPrefab = playerPrefab;
            this.gameStatus = gameStatus;
            this.dataBorder = dataBorder;
        }

        public Unit Spawn(TypeUnits typeUnit)
        {
            var playerGameObject = GameObject.Instantiate(playerPrefab);
            var playerUnit = playerGameObject.GetComponent<Player>();
            IControllerUnit controllerUnit = new ControllerPlayer(gameStatus, dataBorder, playerUnit);
            playerUnit.Initialization(controllerUnit, 100);
            playerUnit.name = $"Player";
            Debug.Log($"Create {playerUnit.name}");
            return playerUnit;
        }
    }
}