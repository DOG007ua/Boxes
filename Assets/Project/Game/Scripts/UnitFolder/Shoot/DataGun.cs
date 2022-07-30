using System;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder.Shoot
{
    [Serializable]
    public class DataGun
    {
        public TypeGun Type;
        public GameObject PrefabBoolet;
        public float TimeReload;
        public float CoefReloadForLevel;
    }
}