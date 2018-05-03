using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public Soldier[] Enemies;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if (GameController.Instance.IsGameOver())
            return;

        // Check if a soldier is currently active
        foreach (Soldier enemy in Enemies)
        {
            if (enemy.mIsActive)
            {
                return;
            }
        }

        int soldier = Random.Range(0, Enemies.Length);
        Enemies[soldier].Activate();
	}
}
