using System;
using Project.Game.Scripts.UnitFolder.Spawn;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Project.Game.Scripts.UnitFolder
{
    public class Unit : MonoBehaviour
    {
        public float HP { get; private set; }
        public IControllerUnit ControlerUnit { get; private set; }
        public event Action<GameObject> destroyUnit;
        public event Action<GameObject> eventSpawn;
        public GameObject GameObjectUnit;
        private IAnimationSpawn animationSpawn;


        public virtual void Initialization(IControllerUnit controlerUnit, IAnimationSpawn animationSpawn, float HP)
        {
            this.HP = HP;
            this.ControlerUnit = controlerUnit;
            this.animationSpawn = animationSpawn;
            AnimationSpawn();
            animationSpawn.finishSpawn += (gameObject) => eventSpawn?.Invoke(gameObject);
        }
        

        private void AnimationSpawn()
        {
            animationSpawn.StartSpawn(GameObjectUnit);
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
