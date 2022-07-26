using System;
using Project.Game.Scripts.UnitFolder;
using UnityEngine;

namespace Project.Core.Spawn
{
    public class CreatorBots : IProduct
    {
        private DataBotsSpawn dataBots;
        private GameStatus gameStatus;

        public CreatorBots(DataBotsSpawn dataBots, GameStatus gameStatus)
        {
            this.dataBots = dataBots;
            this.gameStatus = gameStatus;
        }

        public Unit Spawn(TypeUnits typeUnit)
        {
            var botGameObject = GameObject.Instantiate(dataBots.prefabBots);
            var botUnit = botGameObject.GetComponent<Unit>();
            var controllerBot = new ControllerBot(gameStatus, botGameObject.transform, botUnit);
            botUnit.Initialization(controllerBot, 100);
            return botUnit;
        }
    }
}