using System;
using DG.Tweening;
using Project.Core;
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
        private DataBorder dataBorder;

        protected MoveSystem(GameStatus gameStatus, Transform transform, Unit unit, DataBorder dataBorder)
        {
            this.gameStatus = gameStatus;
            this.transform = transform;
            this.unit = unit;
            this.dataBorder = dataBorder;
        }

        public virtual void Execute()
        {
            UpdatePositionFromDistance();
        }

        public virtual void MoveToDirection(Vector3 vector)
        {
            if (IsBlockMove) return;
            var newPosition = transform.position + vector * Speed * Time.deltaTime;
            transform.position = GetPositionBorder(newPosition);
        }

        private Vector3 GetPositionBorder(Vector3 position)
        {
            if (position.x > dataBorder.XRight) position.x = dataBorder.XRight;
            if (position.x < dataBorder.XLeft) position.x = dataBorder.XLeft;
            if (position.y > dataBorder.YMax) position.y = dataBorder.YMax;
            if (position.y < dataBorder.YMin) position.y = dataBorder.YMin;
            return position;
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