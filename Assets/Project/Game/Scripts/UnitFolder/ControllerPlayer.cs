using Project.Game.Scripts.UnitFolder.Move;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder
{
    public class ControllerPlayer : IControllerUnit
    {
        public IMoveSystem MoveSystem { get; }
        
        public ControllerPlayer(GameStatus gameStatus, Transform transform, Unit unit) 
        {
            MoveSystem = new MoveSystemPlayer(gameStatus, transform, unit);
        }
        
        
    }
}