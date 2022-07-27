using System;
using Project.Game.Scripts.UnitFolder;
using UnityEngine;

namespace Project.Core.Spawn
{
    public class CreatorBots : IProduct
    {
        private DataBotsSpawn dataBots;
        private GameStatus gameStatus;
        private int count = 0;

        public CreatorBots(DataBotsSpawn dataBots, GameStatus gameStatus)
        {
            this.dataBots = dataBots;
            this.gameStatus = gameStatus;
        }

        public Unit Spawn(TypeUnits typeUnit)
        {
            var botGameObject = GameObject.Instantiate(dataBots.prefabBots);
            var botUnit = botGameObject.GetComponent<Bot>();
            botUnit.Initialization(gameStatus, 100);
            botUnit.name = $"Bot_{count}";
            Debug.Log($"Create {botUnit.name}");
            count++;
            return botUnit;
        }
    }
}