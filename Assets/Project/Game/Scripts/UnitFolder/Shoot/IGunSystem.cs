namespace Project.Game.Scripts.UnitFolder.Shoot
{
    public interface IGunSystem
    {
        Gun Gun { get; }
        void Shoot();
        bool CanShoot { get; }
    }
}