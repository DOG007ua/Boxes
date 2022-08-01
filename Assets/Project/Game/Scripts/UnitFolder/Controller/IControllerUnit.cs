using Project.Game.Scripts.UnitFolder.Move;
using Project.Game.Scripts.UnitFolder.Shoot;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder.Controller
{
    public interface IControllerUnit
    {
        IMoveSystem MoveSystem { get; }
        IGunSystem GunSystem { get; }
        void MoveToDirection(Vector3 vector);
        void Shoot();
        void ChangeGun();
        void Execute();
    }
}