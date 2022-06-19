using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] private bool detectingPlayer;
    [SerializeField] private int totalWater;
    private PlayerItems player;

    private void Start()
    {
        player = FindObjectOfType<PlayerItems>();
    }

    private void Update() {
        if(detectingPlayer && Input.GetKeyDown(KeyCode.E)){
            player.WaterLimit(totalWater);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")){
            detectingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        detectingPlayer = false;
    }
}
