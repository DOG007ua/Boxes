using System;
using DG.Tweening;
using Project.Core;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder.Move
{
    public class MoveSystemBot : MoveSystem
    {
        public MoveSystemBot(GameStatus gameStatus, Transform transform, Unit unit, DataBorder dataBorder) 
            : base(gameStatus, transform, unit, dataBorder)
        {
        }

        public override void Execute()
        {
            base.Execute();
        }

        protected override float GetSpeed() => 1f + gameStatus.Level * 0.02f;
    }
}