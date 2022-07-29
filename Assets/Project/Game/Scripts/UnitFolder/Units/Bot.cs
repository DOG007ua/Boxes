﻿using System;
using Project.Game.Scripts.UnitFolder.Spawn;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder
{
    public class Bot : Unit
    {
        public void Initialization(IControllerUnit controllerUnit, IAnimationsUnits animationsUnits, float HP)
        {
            base.Initialization(controllerUnit, animationsUnits, HP);
        }

        private void OnMouseDown()
        {
            Debug.Log($"Damage {name}");
            DamageUnit(100);
        }
    }
}