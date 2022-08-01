using System;
using Project.Game.Scripts.UnitFolder.Controller;
using Project.Game.Scripts.UnitFolder.Spawn;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder.Units
{
    public class Unit : MonoBehaviour
    {
        public event Action<GameObject> eventDestroyUnit;
        public event Action<GameObject> eventSpawn;
        public event Action<float, float> eventChangeHP;
        public float HP { get; private set; }
        public GameObject GunGameObject;
        public IControllerUnit ControllerUnit { get; private set; }
        public GameObject GameObjectUnit;
        [SerializeField] private GameObject gameObjectHP;

        private IVisibleHP visibleHP;
        private IAnimationsUnits animationsUnits;


        public virtual void Initialization(IControllerUnit controllerUnit, IAnimationsUnits animationsUnits, float HP)
        {
            this.HP = HP;
            this.ControllerUnit = controllerUnit;
            this.animationsUnits = animationsUnits;
            AnimationSpawn();
            animationsUnits.finishSpawn += (gameObject) => eventSpawn?.Invoke(gameObject);
            animationsUnits.finishDestroy += DestroyUnit;

            visibleHP = gameObjectHP.GetComponent<IVisibleHP>();
            visibleHP.Initialize(HP);
            eventChangeHP += visibleHP.ChangeHP;
        }
        
        public void DamageUnit(float value)
        {
            Debug.Log($"{name}: damage - {value}");
            HP -= value;
            eventChangeHP?.Invoke(value, HP);
            if (HP <= 0)
                StartDestroyUnit();
        }

        private void AnimationSpawn()
        {
            animationsUnits.StartSpawn(GameObjectUnit);
        }

        private void Update()
        {
            ControllerUnit.Execute();
        }
      

        private void StartDestroyUnit()
        {
            eventDestroyUnit.Invoke(this.gameObject);
            animationsUnits.DestroyUnit(GameObjectUnit);
        }

        private void DestroyUnit(GameObject gameObject)
        {
            Destroy(this.gameObject);
        }
    }
}