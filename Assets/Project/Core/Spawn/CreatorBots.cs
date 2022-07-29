using System;
using Project.Game.Scripts.UnitFolder;
using Project.Game.Scripts.UnitFolder.Spawn;
using UnityEngine;

namespace Project.Core.Spawn
{
    public class CreatorBots : IProduct
    {
        private DataBotsSpawn dataBots;
        private GameStatus gameStatus;
        private int count = 0;
        private DataBorder dataBorder;
        private IAnimationSpawn animationSpawn;
        
        public CreatorBots(DataBotsSpawn dataBots, GameStatus gameStatus, DataBorder dataBorder, IAnimationSpawn animationSpawn)
        {
            this.dataBots = dataBots;
            this.gameStatus = gameStatus;
            this.dataBorder = dataBorder;
            this.animationSpawn = animationSpawn;
        }

        public Unit Spawn(TypeUnits typeUnit)
        {
            var botGameObject = GameObject.Instantiate(dataBots.prefabBots);
            var botUnit = botGameObject.GetComponent<Bot>();
            IControllerUnit controllerUnit = new ControllerBot(gameStatus, dataBorder,  botUnit);
            botUnit.Initialization(controllerUnit, animationSpawn, 100);
            botUnit.name = $"Bot_{count}";
            Debug.Log($"Create {botUnit.name}");
            count++;
            return botUnit;
        }
    }
}