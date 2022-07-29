using Project.Game.Scripts.UnitFolder.Spawn;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder
{
    public class Player : Unit
    {
        public void Initialization(IControllerUnit controllerUnit, IAnimationSpawn animationSpawn, float HP)
        {
            base.Initialization(controllerUnit, animationSpawn, HP);
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