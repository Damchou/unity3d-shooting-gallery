using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Text mTxtHealth;
    public Text mTxtTime;
    public RectTransform mPanelGameOver;
    public RectTransform mPanel;
    public Text mTxtGameOver;


	// Use this for initialization
	void Start () {

        GameController.Instance.GameOverEvent += OnGameOverEvent;
	}

    private void OnGameOverEvent(object sender, EventArgs e)
    {
        mPanelGameOver.gameObject.SetActive(true);
        mPanel.gameObject.SetActive(true);
        mTxtGameOver.text = GameController.Instance.IsWon() ? "YOU WIN" : "YOU LOSE";
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update () {

        mTxtHealth.text = GameController.Instance.GetHealth().ToString();

        mTxtTime.text = GameController.Instance.GetTime().ToString();

    }
}
