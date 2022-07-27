using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus
{
    public int Level { get; private set; }
    public int TotalSecondsGame => (int)(DateTime.Now - timeStartGame).TotalSeconds;
    private DateTime timeStartGame;

    public GameStatus()
    {
        timeStartGame = DateTime.Now;
        Level = 0;
    }

    public void NextLevel()
    {
        Level++;
    }
}
