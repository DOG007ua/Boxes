using Project.Game.Scripts.UnitFolder;
using Project.Game.Scripts.UnitFolder.Move;
using UnityEngine;

namespace Project.Core.Input
{
    public class InputControllerPlayerKey : IInputControllerPlayer
    {
        private IControllerUnit controllerPlayer;
        
        public InputControllerPlayerKey(IControllerUnit controllerPlayer)
        {
            this.controllerPlayer = controllerPlayer;
        }

        public void Execute()
        {
            if (UnityEngine.Input.GetKey(KeyCode.W))
            {
                MoveUp();
            }
            else if (UnityEngine.Input.GetKey(KeyCode.S))
            {
                MoveDown();
            }
        }

        public void MoveUp()
        {
            controllerPlayer.MoveToDirection(Vector3.up);
        }

        public void MoveDown()
        {
            controllerPlayer.MoveToDirection(Vector3.down);
        }
    }
}