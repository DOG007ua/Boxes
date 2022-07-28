using Project.Core;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder.Move
{
    public class MoveSystemPlayer : MoveSystem
    {
        public MoveSystemPlayer(GameStatus gameStatus, Transform transform, Unit unit, DataBorder dataBorder) 
            : base(gameStatus, transform, unit, dataBorder)
        {
        }
        
        public override void Execute()
        {
            base.Execute();
        }

        protected override float GetSpeed() => 1.5f + gameStatus.Level * 0.1f;
    }
}