using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Skeleton : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private AnimController animController;
    private Player player;
    public float health;
    public float totalHealth;
    public Image healthBar;
    public bool isDead;

    private void Start() {
        health = totalHealth;
        player = FindObjectOfType<Player>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update() {
        if(!isDead){
            agent.SetDestination(player.transform.position);

            if(Vector2.Distance(transform.position, player.transform.position) <= agent.stoppingDistance) {
                animController.PlayAnim(2);
            } else {
                animController.PlayAnim(1);
            }

            if(player.transform.position.x > transform.position.x) {
                transform.localScale = new Vector3(1, 1, 1);
            } else {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }

}
