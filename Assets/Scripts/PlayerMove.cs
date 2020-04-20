using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMove : MonoBehaviour
{
    public CharacterController controller;
    public float rotateSpeed;
    public float playerSpeed;

    private Animator _animator;
    private void Start()
    {
        
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        //Move();
    }

    private void Move()
    {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");
        
        var movement = new Vector3(horizontal,0f,vertical);
        
        _animator.SetFloat("Speed",movement.magnitude);
        
        if (Math.Abs(movement.magnitude) > 0)
        {
            transform.rotation = Quaternion.RotateTowards (transform.rotation, Quaternion.LookRotation(movement), rotateSpeed * Time.deltaTime);

        }
        
        controller.SimpleMove(movement * (playerSpeed));
        
    }

    private void FixedUpdate()
    {
        Move();
    }
}
