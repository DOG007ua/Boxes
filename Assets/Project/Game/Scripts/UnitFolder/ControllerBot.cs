using Project.Game.Scripts.UnitFolder.Move;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder
{
    public class ControllerBot: IControllerUnit
    {
        public IMoveSystem MoveSystem { get; }
        
        public ControllerBot(GameStatus gameStatus, Transform transform, Unit unit) 
        {
            MoveSystem = new MoveSystemBot(gameStatus, transform, unit);
        }
    }
}