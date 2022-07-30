using System;
using DG.Tweening;
using Project.Core;
using Project.Game.Scripts.UnitFolder.Units;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder.Move
{
    public class MoveSystemBot : MoveSystem
    {
        public MoveSystemBot(Transform transform, Unit unit, DataBorder dataBorder) 
            : base(transform, unit, dataBorder)
        {
        }

        public override void Execute()
        {
            base.Execute();
        }

        protected override float GetSpeed() => 1f + GameStatusInstance.Instance.Level * 0.02f;
    }
}