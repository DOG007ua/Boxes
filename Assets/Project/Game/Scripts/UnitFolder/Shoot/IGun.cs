using System;

namespace Project.Game.Scripts.UnitFolder.Shoot
{
    public interface IGun
    {
        event Action eventReadyShoot;
        bool ReadyShoot { get; }
        void Shoot();
    }
}