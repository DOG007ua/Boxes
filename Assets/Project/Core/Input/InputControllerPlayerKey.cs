using Project.Game.Scripts.UnitFolder;
using Project.Game.Scripts.UnitFolder.Controller;
using Project.Game.Scripts.UnitFolder.Move;
using UnityEngine;

namespace Project.Core.Input
{
    public class InputControllerPlayerKey : MonoBehaviour, IInputControllerPlayer
    {
        private IControllerUnit controllerPlayer;


        public void Initialize(IControllerUnit controllerPlayer)
        {
            this.controllerPlayer = controllerPlayer;
            this.gameObject.SetActive(true);
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
            else if (UnityEngine.Input.GetKeyDown(KeyCode.R))
            {
                ChangeGun();
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