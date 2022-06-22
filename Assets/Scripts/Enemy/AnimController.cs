using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private Transform atkPoint;
    [SerializeField] private float atkRange;
    [SerializeField] private LayerMask playerLayer;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayAnim(int value){
        anim.SetInteger("transition", value);
    }

    public void Attack(){
        Collider2D hit = Physics2D.OverlapCircle(atkPoint.position, atkRange, playerLayer);

        if(hit != null){
            
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(atkPoint.position, atkRange);
    }
}
