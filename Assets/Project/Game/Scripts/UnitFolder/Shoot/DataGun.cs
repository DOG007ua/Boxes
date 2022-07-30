using System;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder.Shoot
{
    [Serializable]
    public class DataGun
    {
        public TypeGun Type;
        public GameObject PrefabBullet;
        public float TimeReload;
        public float Damage;
        public float CoefReloadForLevel;
    }
}