using System;
using DG.Tweening;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder.Shoot
{
    public class Gun : MonoBehaviour, IGun
    {
        public event Action eventReadyShoot;
        [SerializeField]private Transform pointShoot;
        private DataGun dataGun;
        private string tagEnemy;

        public Gun Initialize(DataGun dataGun, string tagEnemy)
        {
            this.dataGun = dataGun;
            this.tagEnemy = tagEnemy;
            return this;
        }
        

        public bool ReadyShoot { get; private set; } = true;
        
        public void Shoot()
        {
            if (ReadyShoot)
            {
                ShootDown();
                Reload();
            }
        }

        private void ShootDown()
        {
            var bullet = Instantiate(dataGun.PrefabBullet);
            var bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.Initialize(dataGun.Damage, tagEnemy);

            bullet.transform.position = pointShoot.position;        
            //bullet.transform.rotation = Quaternion.LookRotation(pointShoot.position);
            bullet.transform.rotation = pointShoot.rotation;
        }

        private void Reload()
        {
            ReadyShoot = false;
            DOTween.Sequence()
                .AppendInterval(dataGun.TimeReload)
                .AppendCallback(() => FinishReload());
        }

        private void FinishReload()
        {
            ReadyShoot = true;
            eventReadyShoot?.Invoke();
        }
    }
}