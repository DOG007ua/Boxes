using UnityEngine;

namespace Project.Game.Scripts.UnitFolder
{
    public class Player : Unit
    {
        public void Initialization(GameStatus gameStatus, GameObject gameObject, float HP)
        {
            IControllerUnit controllerUnit = new ControllerPlayer(gameStatus, transform, this);
            base.Initialization(controllerUnit, gameObject, HP);
        }

        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}