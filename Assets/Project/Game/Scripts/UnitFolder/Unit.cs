using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Project.Game.Scripts.UnitFolder
{
    public class Unit : MonoBehaviour
    {
        public float HP { get; private set; }
        
        public event Action<GameObject> destroyUnit;
        private GameStatus gameStatus;

        public void Initialization(GameStatus gameStatus, float HP)
        {
            this.gameStatus = gameStatus;
            this.HP = HP;
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
