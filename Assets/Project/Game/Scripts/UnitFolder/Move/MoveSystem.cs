using DG.Tweening;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder.Move
{
    public abstract class MoveSystem : IMoveSystem
    {
        public bool IsBlockMove
        {
            get => isBlockMove;
            set
            {
                isBlockMove = value;
                Stop();
            }
        }
        
        public float Speed => GetSpeed();
        protected GameStatus gameStatus;
        protected Transform transform;
        protected Unit unit;
        protected Vector3 positionMove;
        private bool isBlockMove = false;
        private Tween tweenMove;
        

        protected MoveSystem(GameStatus gameStatus, Transform transform, Unit unit)
        {
            this.gameStatus = gameStatus;
            this.transform = transform;
            this.unit = unit;
        }

        public virtual void Execute(){} //сделать абстрактным
        public void MoveToPosition(Vector3 position)
        {
            if (IsBlockMove) return;
            
            positionMove = position;
            tweenMove.Kill();
            tweenMove = transform.DOMove(position, Speed);
        }

        public void MoveToDirection(Vector3 vector)
        {
            if (IsBlockMove) return;
            transform.position += vector * Speed;
        }

        public void Stop()
        {
            tweenMove.Kill();
        }
        
        protected virtual float GetSpeed() => 1;
    }
}