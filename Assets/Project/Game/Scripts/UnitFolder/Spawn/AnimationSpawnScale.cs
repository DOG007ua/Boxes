using System;
using DG.Tweening;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder.Spawn
{
    public class AnimationSpawnScale : IAnimationSpawn
    {
        public event Action<GameObject> finishSpawn;
        private float time = 1;
        
        public void StartSpawn(GameObject gameObject)
        {
            var scale = gameObject.transform.localScale;
            gameObject.transform.localScale = Vector3.zero;
            gameObject.transform.DOScale(scale, 1);
            DOTween.Sequence()
                .AppendCallback(() => gameObject.transform.DOScale(scale, time))
                .AppendInterval(time)
                .AppendCallback(() => finishSpawn?.Invoke(gameObject));
        }
    }
}