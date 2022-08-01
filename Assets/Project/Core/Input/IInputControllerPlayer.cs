using Project.Game.Scripts.UnitFolder;
using Project.Game.Scripts.UnitFolder.Controller;

namespace Project.Core.Input
{
    public interface IInputControllerPlayer
    {
        void Initialize(IControllerUnit controllerPlayer);
        void MoveUp();
        void MoveDown();
        void Shoot();
        void ChangeGun();
    }
}