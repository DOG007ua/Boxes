using System;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder.Spawn
{
    public interface IAnimationSpawn
    {
        void StartSpawn(GameObject gameObject);
        event Action<GameObject> finishSpawn;
    }
}