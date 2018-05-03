using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootHandler : MonoBehaviour {

    private AudioSource mAudioSrc;

    void Start()
    {
        mAudioSrc = GetComponent<AudioSource>();
    }

    private void ShootEvent()
    {
        int doShoot = Random.Range(0, 2);
        mAudioSrc.Play();

        if (doShoot > 0)
        {
            
            int damage = Random.Range(0, 15);
            GameController.Instance.SetDamage(damage);
        }

    }

}
