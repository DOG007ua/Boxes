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

        public Vector3 Position => transform.position;
        public event Action finishMove;
        public float Speed => GetSpeed();
        protected GameStatus gameStatus;
        public Transform transform;
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
            var time = Vector3.Distance(transform.position, position) / Speed;
            tweenMove = transform.DOMove(position, time);
        }
        
        private void UpdatePositionFromDistance()
        {
            if (isMoveToPosition && IsNeedChangePosition())
            {
                isMoveToPosition = false;
                Stop();
                Debug.Log("finishMove");
                finishMove?.Invoke();
            }
        }
        
        private bool IsNeedChangePosition()
        {
            var distance = Vector3.Distance(transform.position, positionMove);
            Debug.Log($"Distance {distance}");
            return distance < 0.1f;
        }
        
        protected virtual float GetSpeed() => 1;
    }
}