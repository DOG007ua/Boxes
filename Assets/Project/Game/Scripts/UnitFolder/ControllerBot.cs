using DG.Tweening;
using Project.Core;
using Project.Game.Scripts.UnitFolder.Move;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Project.Game.Scripts.UnitFolder
{
    public class ControllerBot: IControllerUnit
    {
        public IMoveSystem MoveSystem { get; }
        public void MoveToDirection(Vector3 vector)
        {
            MoveSystem.MoveToDirection(vector);
        }

        public void Execute()
        {
            MoveSystem.Execute();
        }

        private DataBorder dataBorder;
        
        public ControllerBot(GameStatus gameStatus, DataBorder dataBorder, Unit unit) 
        {
            MoveSystem = new MoveSystemBot(gameStatus, unit.GameObjectUnit.transform, unit, dataBorder);
            MoveSystem.finishMove += NewPosition;
            this.dataBorder = dataBorder;

            DOTween.Sequence()
                .AppendInterval(1)
                .AppendCallback(NewPosition);

        }

        private void NewPosition()
        {
            MoveSystem.MoveToPosition(RandomPosition());
        }

        private Vector3 RandomPosition()
        {
            var posY = Random.Range(dataBorder.YMin, dataBorder.YMax);
            return new Vector3(
                MoveSystem.Position.x,
                posY,
                MoveSystem.Position.z
            );
        }
    }
}