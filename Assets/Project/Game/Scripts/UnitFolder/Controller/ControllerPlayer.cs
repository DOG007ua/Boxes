using Project.Core;
using Project.Game.Scripts.UnitFolder.Move;
using Project.Game.Scripts.UnitFolder.Shoot;
using Project.Game.Scripts.UnitFolder.Units;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder.Controller
{
    public class ControllerPlayer : IControllerUnit
    {
        public IMoveSystem MoveSystem { get; }
        public IGunSystem GunSystem { get; }
        private DataBorder dataBorder;
        private ListGuns listGuns;
        private int positionGun = 0;
        private AnimationPlayer animationPlayer;
        
        public ControllerPlayer(DataBorder dataBorder, Unit unit, IGunSystem gunSystem, 
            ListGuns listGuns, AnimationPlayer animationPlayer)
        {
            this.dataBorder = dataBorder;
            this.listGuns = listGuns;
            this.animationPlayer = animationPlayer;
            MoveSystem = new MoveSystemPlayer(unit.GameObjectUnit.transform, unit, dataBorder);
            GunSystem = gunSystem;
            CalculationPositionGunInList();
            Subscription();
        }

        private void Subscription()
        {
            GunSystem.Gun.eventReadyShoot += animationPlayer.FinishReload;
            GunSystem.Gun.eventShoot += animationPlayer.Reload;
        }
        
        private void UnSubscription()
        {
            GunSystem.Gun.eventReadyShoot -= animationPlayer.FinishReload;
            GunSystem.Gun.eventShoot -= animationPlayer.Reload;
        }
       
        
        public void MoveToDirection(Vector3 vector)
        {
            MoveSystem.MoveToDirection(vector);
        }

        public void Shoot()
        {
            MoveSystem.Stop();
            GunSystem.Shoot();
        }

        public void Execute()
        {
            MoveSystem.Execute();
        }

        public void ChangeGun()
        {
            positionGun++;
            if (positionGun >= listGuns.Guns.Count) positionGun = 0;
            var gun = listGuns.Guns[positionGun];
            
            GunSystem.Gun.ChangeGun(gun);
        }
        
        private void CalculationPositionGunInList()
        {
            for (int i = 0; i < listGuns.Guns.Count; i++)
            {
                if (listGuns.Guns[i].Type == GunSystem.Gun.TypeGun)
                {
                    positionGun = i;
                }
            }
        }
    }
}