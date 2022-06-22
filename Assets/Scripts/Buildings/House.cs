using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{   
    [Header("Amounts")]
    [SerializeField] private int _woodAmount;
    [SerializeField] private GameObject houseCollider;
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;

    [Header("Components")]
    [SerializeField] private float duration;
    [SerializeField] private SpriteRenderer houseSprite;
    [SerializeField] private Transform point;

    [SerializeField] private bool detectingPlayer;
    private Player player;
    private PlayerAnim playerAnim;
    private PlayerItems playerItems;

    private float timeCount;
    private bool isBegining;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        playerAnim = player.GetComponent<PlayerAnim>();
        playerItems = player.GetComponent<PlayerItems>();
    }

    private void Update() {
        if(detectingPlayer && Input.GetKeyDown(KeyCode.E) && playerItems.totalWood >= _woodAmount){
            isBegining = true;
            playerAnim.OnHammeringStart();
            houseSprite.color = startColor;
            player.transform.position = point.position;

            playerItems.totalWood -= _woodAmount;
        }

        if(isBegining){
            timeCount += Time.deltaTime;

            if(timeCount >= duration){
                playerAnim.OnHammeringEnded();
                houseSprite.color = endColor;
                houseCollider.SetActive(true);
            }
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
