using System;
using Project.Game.Scripts.UnitFolder;
using Project.Game.Scripts.UnitFolder.Spawn;
using UnityEngine;

namespace Project.Core.Spawn
{
    public class CreatorBots : IProduct
    {
        private DataBotsSpawn dataBots;
        private int count = 0;
        private DataBorder dataBorder;
        
        public CreatorBots(DataBotsSpawn dataBots, DataBorder dataBorder)
        {
            this.dataBots = dataBots;
            this.dataBorder = dataBorder;
        }

        public Unit Spawn(TypeUnits typeUnit)
        {
            var botGameObject = GameObject.Instantiate(dataBots.prefabBots);
            var botUnit = botGameObject.GetComponent<Bot>();
            IControllerUnit controllerUnit = new ControllerBot(dataBorder,  botUnit);
            IAnimationsUnits animations = new AnimationsUnitsScale();
            botUnit.Initialization(controllerUnit, animations, 100);
            botUnit.name = $"Bot_{count}";
            Debug.Log($"Create {botUnit.name}");
            count++;
            return botUnit;
        }
    }
}