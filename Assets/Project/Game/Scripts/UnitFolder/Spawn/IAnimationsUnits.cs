using System;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder.Spawn
{
    public interface IAnimationsUnits
    {
        void StartSpawn(GameObject gameObject);
        void DestroyUnit(GameObject gameObject);
        event Action<GameObject> finishSpawn;
        event Action<GameObject> finishDestroy;
    }
}