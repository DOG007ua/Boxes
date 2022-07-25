namespace Project.Game.Scripts.UnitFolder
{
    public class Bot : Unit
    {
        public void Initialization(GameStatus gameStatus, float HP)
        {
            IControllerUnit controllerUnit = new ControllerPlayer(gameStatus, transform, this);
            base.Initialization(controllerUnit, HP);
        }
    }
}