using Project.Game.Scripts.UnitFolder.Move;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder
{
    public interface IControllerUnit
    {
        IMoveSystem MoveSystem { get; }
        void MoveToDirection(Vector3 vector);
        void Execute();
    }
}