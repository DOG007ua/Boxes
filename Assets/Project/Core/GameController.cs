﻿using System;
using Project.Core.Spawn;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Core
{
    public class GameController
    {
        public event Action<int> eventNextLevel;
        private Spawner Spawner;

        public GameController(Spawner spawner)
        {
            Spawner = spawner;
            Subscription();
        }

        private void Subscription()
        {
            Spawner.finishLevel += NextLevel;
            Spawner.Player.eventDestroyUnit += FinishGame;
        }

        private void UnSubscription()
        {
            Spawner.finishLevel -= NextLevel;
            Spawner.Player.eventDestroyUnit -= FinishGame;
        }

        private void NextLevel()
        {
            GameStatusInstance.Instance.NextLevel();
            Spawner.NextLevel();
            eventNextLevel?.Invoke(GameStatusInstance.Instance.Level);
            Debug.Log($"Next Level {GameStatusInstance.Instance.Level}");
        }

        private void FinishGame(GameObject gameObject)
        {
            GameStatusInstance.Instance.ResetLevel();
            SceneManager.LoadScene("MainScene");
        }
    }
}