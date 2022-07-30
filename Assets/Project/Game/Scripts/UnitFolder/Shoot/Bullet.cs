using Project.Game.Scripts.UnitFolder.Units;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder.Shoot
{
    public class Bullet : MonoBehaviour
    {
        private float damage = 10;
        private float time = 0;
        private float speed = 20;
        private string tagEnemy;
        

        public void Initialize(float damage, string tagEnemy)
        {
            this.damage = damage;
            this.tagEnemy = tagEnemy;
            Debug.Log($"Spawn {name}");
        }

        // Update is called once per frame
        void Update()
        {
            transform.position += speed * transform.right * Time.deltaTime;
            time += Time.deltaTime;
            if(time > 2)
            {
                Destroy(this.gameObject);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.transform.tag == tagEnemy)
            {
                var unit = collision.transform.GetComponent<Unit>();
                unit.DamageUnit(damage);
                Destroy(this.gameObject);
            }
        }
    }
}