using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float runSpeed;
    private float initialSpeed;
    private bool _isRunning;
    private bool _isRolling;
    private Rigidbody2D rig;
    private Vector2 _direction;

    public Vector2 direction
    {
        get { return _direction; }
        set
        {
            _direction = value;
        }
    }

    public bool isRunning
    {
        get { return _isRunning; }
        set
        {
            _isRunning = value;
        }
    }

    public bool isRolling
    {
        get { return _isRolling; }
        set
        {
            _isRolling = value;
        }
    }

    private void Start()
    {
        initialSpeed = speed;
        rig = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        OnInput();
    }

    private void FixedUpdate()
    {
        OnMove();
        OnRun();
        OnRolling();
    }

    #region Moviment
    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }
    void OnMove()
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    void OnRun()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
            _isRunning = true;
        }
        else
        {
            speed = initialSpeed;
            _isRunning = false;
        }
    }

    void OnRolling()
    {
        if (Input.GetButton("Jump"))
        {
            _isRolling = true;
        }
        else
        {
            _isRolling = false;
        }
    }

    #endregion
}
