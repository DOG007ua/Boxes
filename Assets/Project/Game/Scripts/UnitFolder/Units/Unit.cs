using System;
using Project.Game.Scripts.UnitFolder.Spawn;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder.Units
{
    public class Unit : MonoBehaviour
    {
        public float HP { get; private set; }
        public GameObject GunGameObject; 

        public IControlerUnit ControlerUnit { get; private set; }
        public event Action<GameObject> eventDestroyUnit;
        public event Action<GameObject> eventSpawn;
        [SerializeField] private GameObject gameObjectHP;
        public GameObject GameObjectUnit;
        private IVisibleHP visibleHP;
        private IAnimationsUnits animationsUnits;
        private event Action<float, float> eventChangeHP;
        
        public virtual void Initialization(IControlerUnit controlerUnit, IAnimationsUnits animationsUnits, float HP)
        {
            this.HP = HP;
            this.ControlerUnit = controlerUnit;
            this.animationsUnits = animationsUnits;
            AnimationSpawn();
            animationsUnits.finishSpawn += (gameObject) => eventSpawn?.Invoke(gameObject);
            animationsUnits.finishDestroy += DestroyUnit;

            visibleHP = gameObjectHP.GetComponent<IVisibleHP>();
            visibleHP.Initialize(HP);
            eventChangeHP += visibleHP.ChangeHP;
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
            eventDestroyUnit.Invoke(this.gameObject);
            animationsUnits.DestroyUnit(GameObjectUnit);
        }
        
        private void DestroyUnit(GameObject gameObject)
        {
            Destroy(this.gameObject);
        }

        public void DamageUnit(float value)
        {
            Debug.Log($"{name}: damage - {value}");
            HP -= value;
            eventChangeHP?.Invoke(value, HP);
            if (HP <= 0)
                StartDestroyUnit();
        }
    }
}
