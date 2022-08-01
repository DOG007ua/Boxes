using System;
using DG.Tweening;
using Project.Core;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder.Shoot
{
    public class Gun : MonoBehaviour
    {
        public event Action eventReadyShoot;
        public event Action eventShoot;
        public TypeGun TypeGun { get; private set; }
        [SerializeField]private Transform pointShoot;
        private DataGun dataGun;
        private string tagEnemy;

        public Gun Initialize(DataGun dataGun, string tagEnemy)
        {
            this.dataGun = dataGun;
            this.tagEnemy = tagEnemy;
            TypeGun = this.dataGun.Type;
            return this;
        }

        public void ChangeGun(DataGun dataGun)
        {
            this.dataGun = dataGun;
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
            bullet.transform.rotation = pointShoot.rotation;
            
            eventShoot?.Invoke();
        }

        private void Reload()
        {
            ReadyShoot = false;
            DOTween.Sequence()
                .AppendInterval(GetTimeReload())
                .AppendCallback(() => FinishReload());
        }

        private float GetTimeReload()
        {
            var timeReload = dataGun.TimeReload * (1 - (dataGun.CoefReloadForLevel * GameStatusInstance.Instance.Level));
            if (timeReload < dataGun.TimeReload / 3) timeReload = dataGun.TimeReload / 3;
            
            return timeReload;
        }

        private void FinishReload()
        {
            ReadyShoot = true;
            eventReadyShoot?.Invoke();
        }
    }
}