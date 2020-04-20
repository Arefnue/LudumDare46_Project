using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent _agent;
    public List<GameObject> targetList;
    private GameObject _target;
    private float _attackRange;
    private float _attackDamage = 5f;
    public EnemyProfile profile;
    public Transform hitPoint;
    public GameObject hitParticle;
    public enum State
    {
        Idle,
        Chase,
        Attack,
        Death,
        Busy
    }

    private State _state = State.Idle;
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        FindTarget();
        _attackDamage = profile.damage;
        _attackRange = profile.attackRange;
        _agent.speed = profile.speed;

    }

    private void Update()
    {
        if (_state == State.Busy)
        {
            
        }
        else
        {
            FindTarget();
            CalculateDistanceToTarget();
        }
        
        

        switch (_state)
        {
            case State.Idle:
                break;
            case State.Chase:
                Move();
                break;
            case State.Attack:
                StartCoroutine(Attack());
                break;
            case State.Death:
                break;
            case State.Busy:
                break;
            default:
                break;
        }
    }

    private void CalculateDistanceToTarget()
    {
        if (Vector3.Distance(transform.position,_target.transform.position)<= _attackRange)
        {
            _state = State.Attack;
        }
        else
        {
            _state = State.Chase;
        }
    }

    private IEnumerator Attack()
    {
        _state = State.Busy;
        _agent.SetDestination(transform.position);
        _animator.SetBool("Attack",true);
        transform.LookAt(_target.transform);
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        //Attack animation
        if (Vector3.Distance(transform.position,_target.transform.position)<= _attackRange)
        {
            //Damage here   
            DealDamage();
        }

        yield return new WaitForSeconds(0.1f);
        _animator.SetBool("Attack",false);
        _state = State.Idle;
    }

    public void DealDamage()
    {
        Instantiate(hitParticle, hitPoint.position, Quaternion.identity);
        HealthManager.instance.TakeDamage(_attackDamage);
    }
    

    public void FindTarget()
    {
        _target = GameObject.FindGameObjectWithTag("Companion").gameObject;
    }

    public void Move()
    {
        _agent.SetDestination(_target.transform.position);
        _animator.SetFloat("Speed",_agent.velocity.magnitude);
        
    }
    
    
    
}
