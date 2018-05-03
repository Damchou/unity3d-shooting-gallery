using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

    private AudioSource mAudioSrc;

	// Use this for initialization
	void Start () {
        // Hide mouse cursor
        Cursor.visible = false;

        GameController.Instance.GameOverEvent += OnGameOverEvent;
        mAudioSrc = GetComponent<AudioSource>();
	}

    private void OnGameOverEvent(object sender, EventArgs e)
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        this.transform.position = Input.mousePosition;

        if(Input.GetMouseButtonDown(0))
        {
            mAudioSrc.Play();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform.gameObject.tag == "Enemy")
                {
                    hit.transform.parent.GetComponent<Soldier>().Hit();
                }
            }
        }
	}
}
