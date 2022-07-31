using System.Linq;
using Project.Game.Scripts.UnitFolder;
using Project.Game.Scripts.UnitFolder.Shoot;
using Project.Game.Scripts.UnitFolder.Spawn;
using Project.Game.Scripts.UnitFolder.Units;
using UnityEngine;

namespace Project.Core.Spawn
{
    public class CreatorPlayer : IProduct
    {
        private GameObject playerPrefab;
        private DataBorder dataBorder;
        private ListGuns listGuns;
        
        public CreatorPlayer(GameObject playerPrefab, DataBorder dataBorder, ListGuns listGuns)
        {
            this.playerPrefab = playerPrefab;
            this.dataBorder = dataBorder;
            this.listGuns = listGuns;
        }

        public Unit Spawn(TypeUnits typeUnit, TypeGun typeGun)
        {
            var playerGameObject = GameObject.Instantiate(playerPrefab);
            var playerUnit = playerGameObject.GetComponent<Player>();
            
            
            var gunData = listGuns.Guns.FirstOrDefault(v => v.Type == typeGun);
            var gun = playerUnit.GunGameObject.GetComponent<Gun>().Initialize(gunData, "Bot");
            
            IGunSystem gunSystem = new GunSystem(gun);
            var animationPlayer = playerGameObject.GetComponent<AnimationPlayer>();
            IControlerUnit controlerUnit = new ControlerPlayer(dataBorder, playerUnit, gunSystem, listGuns, animationPlayer);
            IAnimationsUnits animations = new AnimationsUnitsScale();
            playerUnit.Initialization(controlerUnit, animations, 100);
            playerUnit.name = $"Player";
            Debug.Log($"Create {playerUnit.name}");
            return playerUnit;
        }
    }
}