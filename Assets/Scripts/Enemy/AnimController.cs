using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private Transform atkPoint;
    [SerializeField] private float atkRange;
    [SerializeField] private LayerMask playerLayer;

    private PlayerAnim playerAnim;
    private Skeleton skeleton;
    private void Start()
    {
        anim = GetComponent<Animator>();
        playerAnim = FindObjectOfType<PlayerAnim>();
        skeleton = GetComponent<Skeleton>();
    }

    public void PlayAnim(int value){
        anim.SetInteger("transition", value);
    }

    public void Attack(){
        if(!skeleton.isDead){
            Collider2D hit = Physics2D.OverlapCircle(atkPoint.position, atkRange, playerLayer);

            if(hit != null){
                playerAnim.OnHit();
            }
        }
    }

    public void OnHit(){
        if(skeleton.health <= 0){
            skeleton.isDead = true;
            anim.SetTrigger("death");

            Destroy(skeleton.gameObject, 1f);
        }else{
            anim.SetTrigger("hit");

            skeleton.health --;

            skeleton.healthBar.fillAmount = skeleton.health / skeleton.totalHealth;
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(atkPoint.position, atkRange);
    }
}
