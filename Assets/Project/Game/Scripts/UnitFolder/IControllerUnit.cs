using Project.Game.Scripts.UnitFolder.Move;

namespace Project.Game.Scripts.UnitFolder
{
    public interface IControllerUnit
    {
        IMoveSystem MoveSystem { get; }
    }
}