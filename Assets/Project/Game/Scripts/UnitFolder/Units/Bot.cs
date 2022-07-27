using System;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder
{
    public class Bot : Unit
    {

        public void Initialization(IControllerUnit controllerUnit, GameStatus gameStatus, float HP)
        {
            base.Initialization(controllerUnit, HP);
        }

        private void OnMouseDown()
        {
            Debug.Log($"Damage {name}");
            DamageUnit(100);
        }
    }
}