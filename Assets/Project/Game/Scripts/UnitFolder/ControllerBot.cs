using DG.Tweening;
using Project.Core;
using Project.Game.Scripts.UnitFolder.Move;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder
{
    public class ControllerBot: IControllerUnit
    {
        public IMoveSystem MoveSystem { get; }
        public void Execute()
        {
            MoveSystem.Execute();
        }

        private DataBorder dataBorder;
        
        public ControllerBot(GameStatus gameStatus, DataBorder dataBorder ,Transform transform, Unit unit) 
        {
            MoveSystem = new MoveSystemBot(gameStatus, transform, unit);
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