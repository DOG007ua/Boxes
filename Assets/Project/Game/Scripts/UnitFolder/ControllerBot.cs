using Project.Core;
using Project.Game.Scripts.UnitFolder.Move;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder
{
    public class ControllerBot: IControllerUnit
    {
        public IMoveSystem MoveSystem { get; }
        private DataBorder dataBorder;
        
        public ControllerBot(GameStatus gameStatus, DataBorder dataBorder ,Transform transform, Unit unit) 
        {
            MoveSystem = new MoveSystemBot(gameStatus, transform, unit);
            this.dataBorder = dataBorder;
        }
        
        
    }
}