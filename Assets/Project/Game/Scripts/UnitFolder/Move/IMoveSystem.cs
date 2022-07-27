using System;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder.Move
{
    public interface IMoveSystem
    {
        Vector3 Position { get; }
        event Action finishMove;
        void Execute();
        void MoveToPosition(Vector3 position);
        void MoveToDirection(Vector3 vector3);
        void Stop();
        bool IsBlockMove { get; set; }
    }
}