﻿using Project.Game.Scripts.UnitFolder.Move;
using Project.Game.Scripts.UnitFolder.Shoot;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder
{
    public interface IControlerUnit
    {
        IMoveSystem MoveSystem { get; }
        IGunSystem GunSystem { get; }
        void MoveToDirection(Vector3 vector);
        void Shoot();
        void ChangeGun();
        void Execute();
    }
}