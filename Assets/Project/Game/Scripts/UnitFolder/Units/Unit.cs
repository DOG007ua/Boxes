using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Project.Game.Scripts.UnitFolder
{
    public class Unit : MonoBehaviour
    {
        public float HP { get; private set; }
        public event Action<GameObject> destroyUnit;
        public GameObject GameObjectUnit;
        protected IControllerUnit controlelrUnit;

        public virtual void Initialization(IControllerUnit controlelrUnit, float HP)
        {
            this.HP = HP;
            this.controlelrUnit = controlelrUnit;
        }

        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        
        public void DestroyUnit()
        {
            destroyUnit.Invoke(this.gameObject);
            Destroy(this.gameObject);
        }

        public void DamageUnit(float value)
        {
            HP -= value;
            if (HP <= 0)
                DestroyUnit();
        }
    }
}
