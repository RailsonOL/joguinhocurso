using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;
    private Animator anim;
    private SpriteRenderer _spriteRenderer;
    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
        OnRun();
    }

    #region Movement
    public void OnMove()
    {
        if (player.direction.sqrMagnitude > 0)
        { // if the player is moving
            if (player.isRolling)
            {
                anim.SetTrigger("isRoll");
            }
            else
            {
                anim.SetInteger("transition", 1);
            }

            anim.SetInteger("transition", 1);
        }
        else
        {
            anim.SetInteger("transition", 0);
        }

        if (player.direction.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (player.direction.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }

    void OnRun()
    {
        if (player.isRunning && player.direction.sqrMagnitude > 0)
        { // if the player is moving and is running
            anim.SetInteger("transition", 2);
        }
    }

    #endregion
}
