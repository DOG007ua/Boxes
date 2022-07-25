using UnityEngine;

namespace Project.Game.Scripts.UnitFolder.Move
{
    public interface IMoveSystem
    {
        void Execute();
        void MoveToPosition(Vector3 position);
        void MoveToDirection(Vector3 vector3);
        void Stop();
        bool IsBlockMove { get; set; }
    }
}