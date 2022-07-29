using System;
using DG.Tweening;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder.Spawn
{
    public class AnimationsUnitsScale : IAnimationsUnits
    {
        public event Action<GameObject> finishSpawn;
        public event Action<GameObject> finishDestroy;
        private float timeSpawn = 1;
        private float timeDestroy = 0.7f;
        
        public void DestroyUnit(GameObject gameObject)
        {
            DOTween.Sequence()
                .AppendCallback(() => gameObject.transform.DOScale(Vector3.zero, timeDestroy))
                .AppendInterval(timeDestroy)
                .AppendCallback(() => finishDestroy?.Invoke(gameObject));
        }
        
        public void StartSpawn(GameObject gameObject)
        {
            var scale = gameObject.transform.localScale;
            gameObject.transform.localScale = Vector3.zero;
            DOTween.Sequence()
                .AppendCallback(() => gameObject.transform.DOScale(scale, timeSpawn))
                .AppendInterval(timeSpawn)
                .AppendCallback(() => finishSpawn?.Invoke(gameObject));
        }
    }
}