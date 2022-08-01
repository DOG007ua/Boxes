using System;
using Project.Game.Scripts.UnitFolder.Controller;
using UnityEngine;

namespace Project.Core.Input
{
    public class InputController : MonoBehaviour
    {
        [SerializeField]private GameObject InputControllerKey;
        [SerializeField]private GameObject InputControllerButton;

        public void Initialize(IControllerUnit controllerPlayer, params TypeInput[] typeInput)
        {
            foreach (var type in typeInput)
            {
                switch (type)
                {
                    case TypeInput.Button:
                        InputControllerButton.GetComponent<IInputControllerPlayer>()
                            .Initialize(controllerPlayer);
                        break;
                    case TypeInput.Key:
                        InputControllerKey.GetComponent<IInputControllerPlayer>()
                            .Initialize(controllerPlayer);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }

    public enum TypeInput
    {
        Button,
        Key
    }
}