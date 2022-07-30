using Project.Game.Scripts.UnitFolder;
using Project.Game.Scripts.UnitFolder.Move;
using UnityEngine;

namespace Project.Core.Input
{
    public class InputControllerPlayerKey : IInputControllerPlayer
    {
        private IControlerUnit _controlerPlayer;
        
        public InputControllerPlayerKey(IControlerUnit controlerPlayer)
        {
            this._controlerPlayer = controlerPlayer;
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
            else if (UnityEngine.Input.GetKey(KeyCode.E))
            {
                Shoot();
            }
        }

        public void MoveUp()
        {
            _controlerPlayer.MoveToDirection(Vector3.up);
        }

        public void MoveDown()
        {
            _controlerPlayer.MoveToDirection(Vector3.down);
        }

        public void Shoot()
        {
            _controlerPlayer.Shoot();
        }
    }
}