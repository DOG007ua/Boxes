using Project.Game.Scripts.UnitFolder.Spawn;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder.Units
{
    public class Bot : Unit
    {
        public void Initialization(IControlerUnit controlerUnit, IAnimationsUnits animationsUnits, float HP)
        {
            base.Initialization(controlerUnit, animationsUnits, HP);
        }

        private void OnMouseDown()
        {
            Debug.Log($"Damage {name}");
            DamageUnit(100);
        }
    }
}