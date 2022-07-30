namespace Project.Game.Scripts.UnitFolder.Shoot
{
    public interface IGunSystem
    {
        IGun Gun { get; }
        void Shoot();
        bool CanShoot { get; }
    }
}