using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;
    private Animator anim;

    private Casting cast;
    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();

        cast = FindObjectOfType<Casting>();
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

        if(player.direction.x > 0){
            transform.eulerAngles = new Vector2(0, 0);
        }else if (player.direction.x < 0){
            transform.eulerAngles = new Vector2(0, 180);
        }

        if(player.isCuting)
        {
            anim.SetInteger("transition", 3);
        }

        if(player.isDigging){
            anim.SetInteger("transition", 4);
        }

        if(player.isWatering){
            anim.SetInteger("transition", 5);
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

    public void OnCastingStart(){
        anim.SetTrigger("isCasting");
        player.isPaused = true;
    }

    public void OnCastingEnded(){
        cast.OnCasting();
        player.isPaused = false;
    }

    public void OnHammeringStart(){
        anim.SetBool("hammering", true);
        player.isPaused = true;
    }

    public void OnHammeringEnded(){
        anim.SetBool("hammering", false);
        player.isPaused = false;
    }
}
