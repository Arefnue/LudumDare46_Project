﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour
{
    public CollectableProfile profile;
    public GameObject collectParticle;
    public AudioClip collectClip;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (profile.isEnergy)
            {
                HealthManager.instance.IncreaseEnergy(profile.value);
            }
            else
            {
                HealthManager.instance.Heal(profile.value);
            }
            Instantiate(collectParticle, transform.position, Quaternion.identity);
            AudioManager.instance.PlayOneShot(collectClip);
            Destroy(gameObject);
        }

        if (other.CompareTag("Companion"))
        {
            if (profile.isEnergy)
            {
                HealthManager.instance.IncreaseEnergy(profile.value);
            }
            else
            {
                HealthManager.instance.Heal(profile.value);
            }
            Instantiate(collectParticle, transform.position, Quaternion.identity);
            AudioManager.instance.PlayOneShot(collectClip);
            Destroy(gameObject);
        }
    }
    
}
