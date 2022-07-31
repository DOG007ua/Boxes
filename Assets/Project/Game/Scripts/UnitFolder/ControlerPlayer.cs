using Project.Core;
using Project.Game.Scripts.UnitFolder.Move;
using Project.Game.Scripts.UnitFolder.Shoot;
using Project.Game.Scripts.UnitFolder.Units;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder
{
    public class ControlerPlayer : IControlerUnit
    {
        public IMoveSystem MoveSystem { get; }
        public IGunSystem GunSystem { get; }
        private DataBorder dataBorder;
        private ListGuns listGuns;
        private int positionGun = 0;
        
        public ControlerPlayer(DataBorder dataBorder, Unit unit, IGunSystem gunSystem, ListGuns listGuns)
        {
            this.dataBorder = dataBorder;
            this.listGuns = listGuns;
            MoveSystem = new MoveSystemPlayer(unit.GameObjectUnit.transform, unit, dataBorder);
            GunSystem = gunSystem;
            CalculationPositionGun();

        }

        private void CalculationPositionGun()
        {
            for (int i = 0; i < listGuns.Guns.Count; i++)
            {
                if (listGuns.Guns[i].Type == GunSystem.Gun.TypeGun)
                {
                    positionGun = i;
                }
            }
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
    }
}