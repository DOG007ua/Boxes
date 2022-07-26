using System;
using System.Linq;
using Project.Game.Scripts.UnitFolder;
using Project.Game.Scripts.UnitFolder.Controller;
using Project.Game.Scripts.UnitFolder.Shoot;
using Project.Game.Scripts.UnitFolder.Spawn;
using Project.Game.Scripts.UnitFolder.Units;
using UnityEngine;

namespace Project.Core.Spawn
{
    public class CreatorBots : IProduct
    {
        private DataBotsSpawn dataBots;
        private int count = 0;
        private DataBorder dataBorder;
        private ListGuns listGuns;
        private GameObject parent;
        
        public CreatorBots(DataBotsSpawn dataBots, DataBorder dataBorder, ListGuns listGuns)
        {
            parent = new GameObject("Bots");
            this.dataBots = dataBots;
            this.dataBorder = dataBorder;
            this.listGuns = listGuns;
        }

        public Unit Spawn(TypeUnits typeUnit, TypeGun typeGun)
        {
            var botGameObject = GameObject.Instantiate(dataBots.prefabBots);
            var botUnit = botGameObject.GetComponent<Bot>();
            
            var gunData = listGuns.Guns.FirstOrDefault(v => v.Type == typeGun);
            var gun = botUnit.GunGameObject.GetComponent<Gun>().Initialize(gunData, "Player");
            
            IControllerUnit controllerUnit = new ControllerBot(dataBorder, botUnit, gun);
            IAnimationsUnits animations = new AnimationsUnitsScale();
            botUnit.Initialization(controllerUnit, animations, dataBots.HP);
            botUnit.name = $"Bot_{count}";
            botGameObject.transform.parent = parent.transform;
            
            count++;
            return botUnit;
        }
    }
}