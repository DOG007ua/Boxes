using System;
using Project.Game.Scripts.UnitFolder.Spawn;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder
{
    public class Bot : Unit
    {

        public void Initialization(IControllerUnit controllerUnit, IAnimationSpawn animationSpawn, float HP)
        {
            base.Initialization(controllerUnit, animationSpawn, HP);
        }

        private void OnMouseDown()
        {
            Debug.Log($"Damage {name}");
            DamageUnit(100);
        }
    }
}