using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private float treeHealth;
    [SerializeField] private Animator anim;

    [SerializeField] private GameObject woodPrefab;
    [SerializeField] private int totalWood;

    [SerializeField] private ParticleSystem leafs;
    private bool isCuted;
    public void OnHit()
    {
        treeHealth--;

        anim.SetTrigger("isHit");
        leafs.Play();

        if(treeHealth <= 0){
            for(int i = 0; i < totalWood; i++){
                Instantiate(woodPrefab, transform.position, Quaternion.identity);
            }

            anim.SetTrigger("cut");

            isCuted = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("axe") && !isCuted){
            OnHit();
        }
    }
}
