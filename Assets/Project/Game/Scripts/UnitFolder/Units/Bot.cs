using System;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder
{
    public class Bot : Unit
    {

        public void Initialization(GameStatus gameStatus, float HP)
        {
            IControllerUnit controllerUnit = new ControllerBot(gameStatus, transform, this);
            base.Initialization(controllerUnit, HP);
        }

        private void OnMouseDown()
        {
            Debug.Log($"Damage {name}");
            DamageUnit(100);
        }
    }
}