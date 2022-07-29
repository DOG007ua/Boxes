using Project.Game.Scripts.UnitFolder.Spawn;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder
{
    public class Player : Unit
    {
        public void Initialization(IControllerUnit controllerUnit, IAnimationsUnits animationsUnits, float HP)
        {
            base.Initialization(controllerUnit, animationsUnits, HP);
        }

        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}