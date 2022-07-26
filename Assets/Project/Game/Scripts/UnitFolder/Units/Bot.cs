using UnityEngine;

namespace Project.Game.Scripts.UnitFolder
{
    public class Bot : Unit
    {
        public void Initialization(GameStatus gameStatus, GameObject gameObject, float HP)
        {
            IControllerUnit controllerUnit = new ControllerPlayer(gameStatus, transform, this);
            base.Initialization(controllerUnit, gameObject, HP);
        }
    }
}