using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{

    private Rigidbody2D _rigidbody2D;

    [SerializeField]
    public float speed = 2.0f;

    private Vector2 _motionVector;

    public Vector2 LastMotionVector;

    private Animator _animator;

    public bool IsMoving;


    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        _motionVector = new Vector2(horizontal, vertical);

        _animator.SetFloat("horizontal", horizontal);
        _animator.SetFloat("vertical", vertical);


        IsMoving = (horizontal != 0.0f || vertical != 0.0f);
        _animator.SetBool("isMoving", IsMoving);

        if (horizontal != 0.0f || vertical != 0.0f)
        {
            LastMotionVector = new Vector2(horizontal, vertical).normalized;

            _animator.SetFloat("lastHorizontal", horizontal);
            _animator.SetFloat("lastVertical", vertical);
        }
    }

    void FixedUpdate()
    {
        Move();
    }
     
    private void Move()
    {
        _rigidbody2D.velocity = _motionVector * speed;
    }
}
