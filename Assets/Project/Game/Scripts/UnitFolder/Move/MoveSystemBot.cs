using System;
using DG.Tweening;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder.Move
{
    public class MoveSystemBot : IMoveSystem
    {
        public event Action finishMove;
        private Transform transform;
        private Unit unit;
        private Tween tween;
        public bool IsBlockMove
        {
            get => isBlockMove;
            set
            {
                isBlockMove = value;
                Stop();
            }
        }
        private bool isBlockMove = false;
        private bool isMoveToPosition;
        private Vector3 positionMove;


        public void Execute()
        {
            UpdatePositionFromDistance();
        }

        private void UpdatePositionFromDistance()
        {
            if (isMoveToPosition && IsNeedChangePosition())
            {
                finishMove?.Invoke();
            }
        }

        private bool IsNeedChangePosition()
        {
            var distance = Vector3.Distance(transform.position, positionMove);
            return distance < 0.5f;
        }
        
        
        public MoveSystemBot(Transform transform, Unit unit)
        {
            this.transform = transform;
            this.unit = unit;
        }

        public void MoveToPosition(Vector3 position)
        {
            if (IsBlockMove) return;
            positionMove = position;
            tween = transform.DOMove(position, unit.Speed);
        }

        public void MoveToDirection(Vector3 vector)
        {
            if (IsBlockMove) return;
            transform.position += vector * unit.Speed;
        }

        public void Stop()
        {
            tween.Kill();
        }
    }
}