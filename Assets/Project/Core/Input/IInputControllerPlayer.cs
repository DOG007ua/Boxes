using Project.Game.Scripts.UnitFolder;

namespace Project.Core.Input
{
    public interface IInputControllerPlayer
    {
        void Initialize(IControlerUnit controlerPlayer);
        void MoveUp();
        void MoveDown();
        void Shoot();
        void ChangeGun();
    }
}