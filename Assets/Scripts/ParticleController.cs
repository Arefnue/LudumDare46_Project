using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public float delayTime;
    private void Start()
    {
        Invoke("Death",delayTime);
    }


    private void Death()
    {
        Destroy(gameObject);
    }
}
