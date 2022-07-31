using Project.Game.Scripts.UnitFolder;
using UnityEngine;

namespace Project.Core.Input
{
    public class InputControllerPlayerButton : MonoBehaviour, IInputControllerPlayer
    {
        private IControlerUnit controlerPlayer;
        private bool moveUp = false;
        private bool  moveDown = false;
        
        private void Update()
        {
            if (moveUp) MoveUp();
            else if(moveDown) MoveDown();
        }

        public void StartMoveUp()
        {
            moveUp = true;
        }
        
        public void StartMoveDown()
        {
            moveDown = true;
        }

        public void StopMove()
        {
            moveUp = false;
            moveDown = false;
        }

        public void Initialize(IControlerUnit controlerPlayer)
        {
            this.controlerPlayer = controlerPlayer;
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

        public void ChangeGun()
        {
            controlerPlayer.ChangeGun();
        }
    }
}