using Project.Core;
using Project.Game.Scripts.UnitFolder.Units;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder.Move
{
    public class MoveSystemPlayer : MoveSystem
    {
        public MoveSystemPlayer(Transform transform, Unit unit, DataBorder dataBorder) 
            : base(transform, unit, dataBorder)
        {
        }
        
        public override void Execute()
        {
            base.Execute();
        }

        protected override float GetSpeed() => 3f + GameStatusInstance.Instance.Level * 0.1f;
    }
}