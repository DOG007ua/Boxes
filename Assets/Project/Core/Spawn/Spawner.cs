﻿using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Project.Game.Scripts.UnitFolder;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Project.Core.Spawn
{
    public class Spawner
    {
        public event Action deadBot;
        public event Action finishLevel;

        private DataBorder dataBorder;
        private GameStatus gameStatus;
        private IProduct spawnBot;
        private ITypeSpawnUnitSystem typeSpawnUnits;
        private int maxBots = 3;
        private int maxBotsNow;
        private int minBots = 1;
        private float maxTimeSpawn = 5;
        private float minTimeSpawn = 1;
        private int amountBots = 0;
        private List<TypeUnits> listSpawnUnitsInLevel;
        
        public Spawner(GameStatus gameStatus, IProduct spawnBot, ITypeSpawnUnitSystem typeSpawnUnits, DataBorder dataBorder)
        {
            this.gameStatus = gameStatus;
            this.spawnBot = spawnBot;
            this.typeSpawnUnits = typeSpawnUnits;
            this.dataBorder = SetterBorder(dataBorder);
            maxBotsNow = maxBots;
            NextLevel();
            SpawnBot();
            TimerSpawn(2);
        }

        public void NextLevel()
        {
            listSpawnUnitsInLevel = typeSpawnUnits.GetUnitsInLevel(gameStatus.Level);
        }

        private void SpawnBot()
        {
            if (!IsNeedSpawnBot() || listSpawnUnitsInLevel.Count == 0) return;
            
            var needUnit = listSpawnUnitsInLevel.First();
            listSpawnUnitsInLevel.Remove(needUnit);
            
            var bot = spawnBot.Spawn(needUnit);
            
            bot.destroyUnit += DeadBot;
            SetterPositionBot(bot);
                
            amountBots++;
            if (IsNeedSpawnBot())
            {
                TimerSpawn();
            }
        }

        private DataBorder SetterBorder(DataBorder dataBorderScreen)
        {
            var border = new DataBorder
            {
                XLeft = dataBorderScreen.XLeft + 1,
                XRight = dataBorderScreen.XRight - 1,
                YMax = dataBorderScreen.YMax - 1,
                YMin = dataBorderScreen.YMin + 1
            };
            return border;
        }

        private void SetterPositionBot(Unit bot)
        {
            var posY = Random.Range(dataBorder.YMin, dataBorder.YMax);
            var posX = Random.Range(-3, -0.5f);
            bot.gameObject.transform.position = new Vector3(
                dataBorder.XRight + posX,
                posY,
                0
                );
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
            if (listSpawnUnitsInLevel.Count == 0 && amountBots == 0)
            {
                finishLevel?.Invoke();
            }
            else
            {
                TimerSpawn();
            }
        }
    }
}