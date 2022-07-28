using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Project.Game.Scripts.UnitFolder
{
    public class Unit : MonoBehaviour
    {
        public float HP { get; private set; }
        public IControllerUnit ControlerUnit { get; private set; }
        public event Action<GameObject> destroyUnit;
        public GameObject GameObjectUnit;
        

        public virtual void Initialization(IControllerUnit controlelrUnit, float HP)
        {
            this.HP = HP;
            this.ControlerUnit = controlelrUnit;
        }

        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            ControlerUnit.Execute();
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
