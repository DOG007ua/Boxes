using System;
using DG.Tweening;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder.Move
{
    public class MoveSystemBot : MoveSystem
    {
        public event Action finishMove;
        private bool isMoveToPosition;
        
        public MoveSystemBot(GameStatus gameStatus, Transform transform, Unit unit) 
            : base(gameStatus, transform, unit)
        {
        }

        public override void Execute()
        {
            UpdatePositionFromDistance();
        }

        protected override float GetSpeed() => 0.5f + gameStatus.Level * 0.1f;

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
    }
}