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
        
        public ControlerPlayer(DataBorder dataBorder, Unit unit, IGun gun)
        {
            this.dataBorder = dataBorder;
            MoveSystem = new MoveSystemPlayer(unit.GameObjectUnit.transform, unit, dataBorder);
            GunSystem = new GunSystem(gun);
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
    }
}