using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isPaused;

    public float speed;
    public float runSpeed;
    private float initialSpeed;

    private PlayerItems playerItems;

    private bool _isRunning;
    private bool _isRolling;
    private bool _isCuting;
    private bool _isDigging;
    private bool _isWatering;
    private Rigidbody2D rig;
    private Vector2 _direction;

    private int _handlingObj;

    public int handlingObjs { get => _handlingObj; set => _handlingObj = value; }
    public bool isCuting { get { return _isCuting; } set { _isCuting = value; } }
    public Vector2 direction { get { return _direction; } set { _direction = value; } }
    public bool isRunning { get { return _isRunning; } set { _isRunning = value; } }
    public bool isRolling { get { return _isRolling; } set { _isRolling = value; } }
    public bool isDigging { get { return _isDigging; } set { _isDigging = value; } }
    public bool isWatering { get { return _isWatering; } set { _isWatering = value; } }

    private void Start()
    {
        initialSpeed = speed;
        rig = GetComponent<Rigidbody2D>();
        playerItems = GetComponent<PlayerItems>();
    }
    private void Update()
    {
        if (isPaused)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _handlingObj = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _handlingObj = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _handlingObj = 2;
        }

        OnRun();
        OnInput();
        OnWatering();
        OnRolling();
        OnCuting();
        OnDig();
    }

    private void FixedUpdate()
    {
        if (isPaused)
        {
            return;
        }
        OnMove();
    }

    #region Moviment

    void OnWatering()
    {
        if (_handlingObj == 2)
        {
            if (Input.GetMouseButtonDown(0) && playerItems.currentWater > 0)
            {
                _isWatering = true;
                speed = 0;
            }

            if (Input.GetMouseButtonUp(0) || playerItems.currentWater <= 0)
            {
                _isWatering = false;
                speed = initialSpeed;
            }

            if (_isWatering)
            {
                playerItems.currentWater -= 0.1f;
            }
        }
    }

    void OnDig()
    {
        if (_handlingObj == 1)
        {
            if (Input.GetMouseButton(0))
            {
                _isDigging = true;
                speed = 0;
            }
            else
            {
                _isDigging = false;
                speed = initialSpeed;
            }
        }
    }

    void OnCuting()
    {
        if (_handlingObj == 0)
        {
            if (Input.GetMouseButton(0))
            {
                _isCuting = true;
                speed = 0;
            }
            else
            {
                _isCuting = false;
                speed = initialSpeed;
            }
        }
    }
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
