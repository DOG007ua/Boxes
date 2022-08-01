using Project.Game.Scripts.UnitFolder;
using Project.Game.Scripts.UnitFolder.Controller;
using UnityEngine;

namespace Project.Core.Input
{
    public class InputControllerPlayerButton : MonoBehaviour, IInputControllerPlayer
    {
        private IControllerUnit controllerPlayer;
        private bool moveUp = false;
        private bool moveDown = false;

        public void Initialize(IControllerUnit controllerPlayer)
        {
            this.controllerPlayer = controllerPlayer;
            this.gameObject.SetActive(true);
        }

        private void Update()
        {
            if (moveUp) MoveUp();
            else if (moveDown) MoveDown();
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

        public void MoveUp()
        {
            controllerPlayer.MoveToDirection(Vector3.up);
        }

        public void MoveDown()
        {
            controllerPlayer.MoveToDirection(Vector3.down);
        }

        public void Shoot()
        {
            controllerPlayer.Shoot();
        }

        public void ChangeGun()
        {
            controllerPlayer.ChangeGun();
        }
    }
}