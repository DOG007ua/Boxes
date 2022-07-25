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
        
        protected Transform transform;
        protected Unit unit;
        protected Vector3 positionMove;
        private bool isBlockMove = false;
        private Tween tweenMove;

        protected MoveSystem(Transform transform, Unit unit)
        {
            this.transform = transform;
            this.unit = unit;
        }
        
        public virtual void Execute(){} //сделать абстрактным
        public void MoveToPosition(Vector3 position)
        {
            if (IsBlockMove) return;
            
            positionMove = position;
            tweenMove.Kill();
            tweenMove = transform.DOMove(position, unit.Speed);
        }
        

        public void MoveToDirection(Vector3 vector)
        {
            if (IsBlockMove) return;
            transform.position += vector * unit.Speed;
        }

        public void Stop()
        {
            tweenMove.Kill();
        }



        
    }
}