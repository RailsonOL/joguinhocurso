using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;

    [Header("Settings")]
    [SerializeField] private int digAmount;
    [SerializeField] private float waterAmount;
    private float currentWater;
    private bool dugHole;

    PlayerItems playerItems;

    [SerializeField] private bool detected;
        [SerializeField] private bool detectingPlayer;
    private int initialDigAmount;

    private void Start()
    {
        initialDigAmount = digAmount;
        playerItems = GameObject.Find("Player").GetComponent<PlayerItems>();
    }

    private void Update()
    {
        if (dugHole)
        {
            if (detected)
            {
                currentWater += 0.01f;
            }

            if (currentWater >= waterAmount)
            {
                spriteRenderer.sprite = carrot;

                if(detectingPlayer && Input.GetKeyDown(KeyCode.E))
                {
                    currentWater = 0f;
                    spriteRenderer.sprite = hole;
                    playerItems.totalCarrots++;
                }
            }
        }
    }
    public void OnHit()
    {
        digAmount--;
        if (digAmount <= initialDigAmount / 2)
        {
            spriteRenderer.sprite = hole;
            dugHole = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shovel"))
        {
            OnHit();
        }

        if (collision.CompareTag("WateringCan"))
        {
            detected = true;
        }

        if (collision.CompareTag("Player"))
        {
            detectingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("WateringCan"))
        {
            detected = false;
        }

        if (collision.CompareTag("Player"))
        {
            detectingPlayer = false;
        }
    }
}
