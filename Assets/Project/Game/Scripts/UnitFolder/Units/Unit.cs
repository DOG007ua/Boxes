using System;
using Project.Game.Scripts.UnitFolder.Spawn;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder.Units
{
    public class Unit : MonoBehaviour
    {
        public float HP { get; private set; }
        public IControllerUnit ControlerUnit { get; private set; }
        public event Action<GameObject> destroyUnit;
        public event Action<GameObject> eventSpawn;
        public GameObject GameObjectUnit;
        private IAnimationsUnits animationsUnits;


        public virtual void Initialization(IControllerUnit controlerUnit, IAnimationsUnits animationsUnits, float HP)
        {
            this.HP = HP;
            this.ControlerUnit = controlerUnit;
            this.animationsUnits = animationsUnits;
            AnimationSpawn();
            animationsUnits.finishSpawn += (gameObject) => eventSpawn?.Invoke(gameObject);
            animationsUnits.finishDestroy += DestroyUnit;
        }
        

        private void AnimationSpawn()
        {
            animationsUnits.StartSpawn(GameObjectUnit);
        }

        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            ControlerUnit.Execute();
        }
        
        public void StartDestroyUnit()
        {
            destroyUnit.Invoke(this.gameObject);
            animationsUnits.DestroyUnit(GameObjectUnit);
        }
        
        private void DestroyUnit(GameObject gameObject)
        {
            Destroy(this.gameObject);
        }

        public void DamageUnit(float value)
        {
            HP -= value;
            if (HP <= 0)
                StartDestroyUnit();
        }
    }
}
