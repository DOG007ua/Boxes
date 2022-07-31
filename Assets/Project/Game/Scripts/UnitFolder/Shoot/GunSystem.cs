namespace Project.Game.Scripts.UnitFolder.Shoot
{
    public class GunSystem : IGunSystem
    {
        public GunSystem(Gun gun)
        {
            Gun = gun;
        }

        public Gun Gun { get; }
        public void Shoot()
        {
            Gun.Shoot();
        }

        public bool CanShoot => Gun.ReadyShoot;
    }
}