using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class PlayerSwap : MonoBehaviour
{
    public GameObject companionObject;
    public GameObject playerObject;
    public bool isPlayer;
    private CharacterController _controller;
    private NavMeshAgent _agent;
    public GameObject swapParticle;
    public AudioClip swapClip;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (HealthManager.instance.currentEnergy <= 0)
            {
                
            }
            else
            {
                Swap();
            }
            
        }
    }


    private void Swap()
    {
        if (!isPlayer)
        {
            isPlayer = true;
            _agent.enabled = false;
            companionObject.SetActive(false);
            _controller.enabled = true;
            playerObject.SetActive(true);
            AudioManager.instance.PlayOneShot(swapClip);
        }
        else
        {
            isPlayer = false;
            _controller.enabled = false;
            playerObject.SetActive(false);
            _agent.enabled = true;
            companionObject.SetActive(true);
            
        }

        Instantiate(swapParticle, transform.position, Quaternion.identity);

    }
    
}
