﻿using DG.Tweening;
using Project.Core;
using Project.Game.Scripts.UnitFolder.Move;
using Project.Game.Scripts.UnitFolder.Shoot;
using Project.Game.Scripts.UnitFolder.Units;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Project.Game.Scripts.UnitFolder
{
    public class ControlerBot: IControlerUnit
    {
        public IMoveSystem MoveSystem { get; }
        public IGunSystem GunSystem { get; }

        public ControlerBot(DataBorder dataBorder, Unit unit)
        {
            unit.eventSpawn += StartMove;
            MoveSystem = new MoveSystemBot(unit.GameObjectUnit.transform, unit, dataBorder);
            MoveSystem.finishMove += NewPosition;
            
            
            unit.destroyUnit += DestroyUnit;
            this.dataBorder = dataBorder;
        }
        
        public void MoveToDirection(Vector3 vector)
        {
            MoveSystem.MoveToDirection(vector);
        }

        public void Shoot()
        {
            GunSystem.Shoot();
        }

        public void Execute()
        {
            MoveSystem.Execute();
        }

        private DataBorder dataBorder;
        
        

        private void DestroyUnit(GameObject gameObject)
        {
            MoveSystem.Stop();
            MoveSystem.IsBlockMove = true;
        }

        private void StartMove(GameObject bot)
        {
            NewPosition();
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