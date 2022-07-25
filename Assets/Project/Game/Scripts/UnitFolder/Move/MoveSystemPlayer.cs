using UnityEngine;

namespace Project.Game.Scripts.UnitFolder.Move
{
    public class MoveSystemPlayer : MoveSystem
    {
        public MoveSystemPlayer(GameStatus gameStatus, Transform transform, Unit unit) 
            : base(gameStatus, transform, unit)
        {
        }
        
        protected override float GetSpeed() => 0.5f + gameStatus.Level * 0.1f;
    }
}