using DG.Tweening;
using Project.Core;
using Project.Game.Scripts.UnitFolder.Move;
using Project.Game.Scripts.UnitFolder.Shoot;
using Project.Game.Scripts.UnitFolder.Units;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Project.Game.Scripts.UnitFolder
{
    public class ControlerBot: IControlerUnit
    {
        public IMoveSystem MoveSystem { get; }
        public IGunSystem GunSystem { get; }

        private float pauseShoot = 1;
        private Sequence tweenShoot;
        private Sequence tweenPreShoot;
        private Sequence tweenFirstShoot;

        public ControlerBot(DataBorder dataBorder, Unit unit, IGun gun)
        {
            unit.eventSpawn += StartMove;
            MoveSystem = new MoveSystemBot(unit.GameObjectUnit.transform, unit, dataBorder);
            MoveSystem.finishMove += NewPosition;
            GunSystem = new GunSystem(gun);
            GunSystem.Gun.eventReadyShoot += ReadyShoot;
            
            unit.eventDestroyUnit += DOEventDestroyUnit;
            this.dataBorder = dataBorder;
            FirstShoot();
        }

        private void FirstShoot()
        {
            float timeToNextShoot = Random.Range(1, 3);
            tweenFirstShoot = DOTween.Sequence()
                .AppendInterval(timeToNextShoot)
                .AppendCallback(Shoot);
        }
        
        public void MoveToDirection(Vector3 vector)
        {
            MoveSystem.MoveToDirection(vector);
        }

        private void ReadyShoot()
        {
            Debug.Log("ReadyShoot");
            float timeToNextShoot = Random.Range(1.0f, 3.0f);
            tweenPreShoot = DOTween.Sequence()
                .AppendInterval(timeToNextShoot)
                .AppendCallback(Shoot);
        }

        public void Shoot()
        {
            MoveSystem.Stop();
            MoveSystem.IsBlockMove = true;

            tweenShoot = DOTween.Sequence()
                .AppendInterval(pauseShoot)
                .AppendCallback(GunSystem.Shoot)
                .AppendCallback(() => MoveSystem.IsBlockMove = false)
                .AppendCallback(NewPosition);

        }

        public void Execute()
        {
            MoveSystem.Execute();
        }

        private DataBorder dataBorder;
        
        private void DOEventDestroyUnit(GameObject gameObject)
        {
            MoveSystem.Stop();
            MoveSystem.IsBlockMove = true;
            tweenShoot.Kill();
            tweenPreShoot.Kill();
            tweenFirstShoot.Kill();
        }

        private void StartMove(GameObject bot)
        {
            NewPosition();
        }

        private void NewPosition()
        {
            MoveSystem.MoveToPosition(RandomPosition());
        }

        private Vector3 RandomPosition()
        {
            var posY = Random.Range(dataBorder.YMin, dataBorder.YMax);
            return new Vector3(
                MoveSystem.Position.x,
                posY,
                MoveSystem.Position.z
            );
        }
    }
}