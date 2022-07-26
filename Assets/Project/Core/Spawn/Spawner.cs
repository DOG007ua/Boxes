using System;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Project.Core.Spawn
{
    public class Spawner
    {
        public event Action deadBot;

        private GameStatus gameStatus;
        private IProduct spawnBot;
        private int maxBots = 3;
        private int maxBotsNow;
        private int minBots = 1;
        private float maxTimeSpawn = 5;
        private float minTimeSpawn = 1;
        private int amountBots = 0;
        
        public Spawner(GameStatus gameStatus, IProduct spawnBot)
        {
            this.gameStatus = gameStatus;
            this.spawnBot = spawnBot;
            maxBotsNow = maxBots;
            SpawnBot();
            TimerSpawn(2);
        }

        private void SpawnBot()
        {
            if (!IsNeedSpawnBot()) return;
            
            var bot = spawnBot.Spawn();
            amountBots++;
            bot.destroyUnit += DeadBot;
            
            if (IsNeedSpawnBot())
            {
                TimerSpawn();
            }
        }

        private bool IsNeedSpawnBot() => (amountBots < maxBotsNow);
        
        private void TimerSpawn(float seconds)
        {
            DOTween.Sequence()
                .AppendInterval(seconds)
                .AppendCallback(SpawnBot);
        }
        
        private void TimerSpawn()
        {
            var seconds = Random.Range(minTimeSpawn, maxTimeSpawn);
            TimerSpawn(seconds);
        }

        private void DeadBot(GameObject bot)
        {
            amountBots--;
            TimerSpawn();
        }
    }
}