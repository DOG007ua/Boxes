using System;
using DG.Tweening;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder.Move
{
    public class MoveSystemBot : MoveSystem
    {
        public MoveSystemBot(GameStatus gameStatus, Transform transform, Unit unit) 
            : base(gameStatus, transform, unit)
        {
        }

        public override void Execute()
        {
            
        }

        protected override float GetSpeed() => 0.5f + gameStatus.Level * 0.1f;
    }
}