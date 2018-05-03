using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour {

    private GameObject mEnemy;
    public float UpTime = 3.0f;
    public float ShootTime = 2.0f;
    public float DownTime = 2.0f;
    public bool mIsActive = false;
    private Animator mAnimator = null;
    Vector3 mStartPos = Vector3.zero;
    public AudioClip[] mAudioClips;
    private AudioSource scream;

    // Use this for initialization
    void Awake ()
    {

        UpTime = 3.0f;
        ShootTime = 2.0f;
        DownTime = 2.0f;
        mIsActive = false;
        mAnimator = null;
        mStartPos = Vector3.zero;

        mEnemy = transform.GetChild(0).gameObject;
        mStartPos = mEnemy.transform.position;
        mAnimator = mEnemy.GetComponent<Animator>();
        scream = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
		
	}


    public void Activate()
    {
        mIsActive = true;

        mEnemy.transform.position = mStartPos;
        MoveUpwards();

        // Start shooting
        mAnimator.SetBool("shoot", true);

        Invoke("MoveDownwards", ShootTime);
    }

    internal void Hit()
    {
        mAnimator.SetTrigger("die");
        Debug.Log(mAudioClips.Length);
        scream.clip = mAudioClips[UnityEngine.Random.Range(0, mAudioClips.Length)];
        scream.Play();

        Invoke("MoveDownwards", 2.0f);
    }

    public bool isActive
    {
        get { return mIsActive; }
    }

    private void MoveUpwards()
    {
        // Move upwards
        Vector3 enemyPos = mEnemy.transform.position;
        enemyPos.y += 5.0f;

        iTween.MoveTo(mEnemy, enemyPos, UpTime);
    }

    private void MoveDownwards()
    {
        // Stop shooting
        mAnimator.SetBool("shoot", false);

        // Move downwards
        Vector3 enemyPos = mEnemy.transform.position;
        enemyPos.y -= 5.0f;

        iTween.MoveTo(mEnemy, enemyPos, DownTime);

        iTween.MoveTo(mEnemy, iTween.Hash("y", enemyPos.y, "time", DownTime, "onComplete", "OnDownComplete", "onCompleteTarget", gameObject));
    }

    void OnDownComplete()
    {
        mIsActive = false;
    }
}
