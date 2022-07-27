using System;
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
        public event Action finishMove;
        public float Speed => GetSpeed();
        protected GameStatus gameStatus;
        protected Transform transform;
        protected Unit unit;
        protected Vector3 positionMove;
        private bool isBlockMove = false;
        private Tween tweenMove;
        private bool isMoveToPosition;

        protected MoveSystem(GameStatus gameStatus, Transform transform, Unit unit)
        {
            this.gameStatus = gameStatus;
            this.transform = transform;
            this.unit = unit;
        }

        public virtual void Execute()
        {
            UpdatePositionFromDistance();
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
        
        public void MoveToPosition(Vector3 position)
        {
            if (IsBlockMove) return;

            isMoveToPosition = true;
            positionMove = position;
            tweenMove.Kill();
            tweenMove = transform.DOMove(position, Speed);
        }
        
        private void UpdatePositionFromDistance()
        {
            if (isMoveToPosition && IsNeedChangePosition())
            {
                isMoveToPosition = false;
                Stop();
                finishMove?.Invoke();
            }
        }
        
        private bool IsNeedChangePosition()
        {
            var distance = Vector3.Distance(transform.position, positionMove);
            return distance < 0.5f;
        }
        
        protected virtual float GetSpeed() => 1;
    }
}