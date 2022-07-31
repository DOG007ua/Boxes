using Project.Game.Scripts.UnitFolder;
using Project.Game.Scripts.UnitFolder.Move;
using UnityEngine;

namespace Project.Core.Input
{
    public class InputControllerPlayerKey : MonoBehaviour, IInputControllerPlayer
    {
        private IControlerUnit controlerPlayer;
        
        /*public InputControllerPlayerKey(IControlerUnit controlerPlayer)
        {
            this.controlerPlayer = controlerPlayer;
        }*/

        
        public void Initialize(IControlerUnit controlerPlayer)
        {
            this.controlerPlayer = controlerPlayer;
        }
        
        public void Update()
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
            controlerPlayer.MoveToDirection(Vector3.up);
        }

        public void MoveDown()
        {
            controlerPlayer.MoveToDirection(Vector3.down);
        }

        public void Shoot()
        {
            controlerPlayer.Shoot();
        }
    }
}