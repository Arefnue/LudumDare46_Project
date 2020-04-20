using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class CompanionController : MonoBehaviour
{
    public NavMeshAgent agent;
    private PlayerMove _playerMove;
    private GameObject _target;
    public float fleeDistance;
    private Animator _animator;

    public enum State
    {
        Idle,
        Damage,
        Follow,
        Busy,
        Death
    }

    public State state = State.Follow;
    

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _playerMove = FindObjectOfType<PlayerMove>();
    }

    private void Update()
    {
        
        DeterminrState();
        switch (state)
        {
            case State.Idle:
                break;
            case State.Damage:
                StartCoroutine(TakeDamage());
                break;
            case State.Follow:
                FollowPlayer();
                break;
            case State.Death:
                break;
            case State.Busy:
                break;
            default:
                break;
        }
    }

    public void DeterminrState()
    {
        if (state == State.Busy)
        {
            
        }
        else if (state == State.Damage)
        {
            
        }
        else
        {
            state = State.Follow;
        }
    }

    public IEnumerator TakeDamage()
    {
        state = State.Busy;
        yield return new WaitForSeconds(1f);
        Debug.Log("Takedamage");
        state =  State.Idle;
    }
    

    private void FollowPlayer()
    {
        _animator.SetFloat("Speed",agent.velocity.magnitude);
        agent.SetDestination(_playerMove.gameObject.transform.position);
    }
    
}
