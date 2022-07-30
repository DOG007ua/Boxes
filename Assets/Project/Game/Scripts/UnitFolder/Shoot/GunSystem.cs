namespace Project.Game.Scripts.UnitFolder.Shoot
{
    public class GunSystem : IGunSystem
    {
        public GunSystem(IGun gun)
        {
            Gun = gun;
        }

        public IGun Gun { get; }
        public void Shoot()
        {
            Gun.Shoot();
        }

        public bool CanShoot => Gun.ReadyShoot;
    }
}