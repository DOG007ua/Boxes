using System;
using UnityEngine;

namespace Project.Core.Input
{
    public class InputController : MonoBehaviour
    {
        private IInputControllerPlayer inputControlelerPlayer;

        public void Init(IInputControllerPlayer inputControlelerPlayer)
        {
            this.inputControlelerPlayer = inputControlelerPlayer;
        }

        private void Update()
        {
            inputControlelerPlayer.Execute();
        }
    }
}