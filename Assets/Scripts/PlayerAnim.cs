using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] private Transform atkPoint;
    [SerializeField] private float atkRange;
    [SerializeField] private LayerMask enemyLayer;

    private Player player;
    private Animator anim;
    private Casting cast;

    private bool isHitting;
    private float recoveryTime = 1f;
    private float timeCount;
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

        if(isHitting){
            timeCount += Time.deltaTime;
            if(timeCount >= recoveryTime){
                isHitting = false;
                timeCount = 0;
            }
        }
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

    #region Attack

    public void OnAttack()
    {
        Collider2D hit = Physics2D.OverlapCircle(atkPoint.position, atkRange, enemyLayer);
        if (hit != null)
        {
            hit.GetComponent<AnimController>().OnHit();
        }
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(atkPoint.position, atkRange);
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

    public void OnHit(){
        if(!isHitting){
            isHitting = true;
            anim.SetTrigger("isHit");
        }
    }
}
