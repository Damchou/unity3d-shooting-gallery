using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController> {

    protected GameController() { } // guarantee this will be always a singleton only - can't use the constructor!

    private int mHealth = 100;
    private int mTime = 35;
    private bool mGameOver = false;
    public event EventHandler GameOverEvent;

    void Awake()
    {
        mHealth = 100;
        mTime = 35;
        mGameOver = false;
    }

    private void OnGameOver()
    {
        if (GameOverEvent != null)
            GameOverEvent(this, EventArgs.Empty);
    }

    void Start()
    {
        InvokeRepeating("Count", 0.0f, 1.0f);
    }

    void Count()
    {
        if(mTime == 0)
        {
            mGameOver = true;
            CancelInvoke("Count");
            OnGameOver();
        }
        else
        {
            mTime--;
        }
    }

    public void SetDamage(int damage)
    {
        if (mGameOver)
            return;

        mHealth -= damage;

        if(mHealth <= 0)
        {
            mHealth = 0;

            mGameOver = true;
            CancelInvoke("Count");
            OnGameOver();
        }
    }

    public bool IsGameOver()
    {
        return mGameOver;
    }

    public bool IsWon()
    {
        if (mHealth <= 0)
            return false;

        return true;
    }

    public int GetHealth()
    {
        return mHealth;
    }

    public int GetTime()
    {
        return mTime;
    }
}
