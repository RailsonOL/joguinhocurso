using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    [Header("Items")]
    [SerializeField] private Image waterBar;
    [SerializeField] private Image woodBar;
    [SerializeField] private Image carrotBar;
    [SerializeField] private Image fishBar;

    [Header("Tools")]
    // [SerializeField] private Image axe;
    // [SerializeField] private Image shovel;
    // [SerializeField] private Image waterCan;

    public List<Image> toolsUI = new List<Image>();

    [SerializeField] private Color selectedColor;
    [SerializeField] private Color alphaColor;

    private PlayerItems playerItems;
    private Player player;
    private void Awake() {
        playerItems = GameObject.Find("Player").GetComponent<PlayerItems>();
        player = playerItems.GetComponent<Player>();
    }

    private void Start() {
        waterBar.fillAmount = 0;
        woodBar.fillAmount = 0;
        carrotBar.fillAmount = 0;
        fishBar.fillAmount = 0;
    }

    private void Update() {
        waterBar.fillAmount = playerItems.currentWater / playerItems.waterLimit;
        woodBar.fillAmount = playerItems.totalWood / playerItems.woodLimit;
        carrotBar.fillAmount = playerItems.totalCarrots / playerItems.carrotLimit;
        fishBar.fillAmount = playerItems.totalFishs / playerItems.fishsLimit;

        toolsUI[player.handlingObjs].color = selectedColor;

        for (int i = 0; i < toolsUI.Count; i++) {
            if (i != player.handlingObjs) {
                toolsUI[i].color = alphaColor;
            }
        }
    }
}
