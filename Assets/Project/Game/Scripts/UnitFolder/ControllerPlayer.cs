using Project.Core;
using Project.Game.Scripts.UnitFolder.Move;
using Project.Game.Scripts.UnitFolder.Units;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder
{
    public class ControllerPlayer : IControllerUnit
    {
        public IMoveSystem MoveSystem { get; }
        private DataBorder dataBorder;
        
        public ControllerPlayer(DataBorder dataBorder, Unit unit)
        {
            this.dataBorder = dataBorder;
            MoveSystem = new MoveSystemPlayer(unit.GameObjectUnit.transform, unit, dataBorder);
        }

        public void MoveToDirection(Vector3 vector)
        {
            MoveSystem.MoveToDirection(vector);
        }

        public void Execute()
        {
            MoveSystem.Execute();
        }
    }
}