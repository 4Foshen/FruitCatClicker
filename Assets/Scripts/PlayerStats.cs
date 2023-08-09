using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [Header("Texts")]
    public Text score;
    public Text diamondText;
    public Text currentIncome;
    public Text currentCoinPC;
    public Text currentRespawn;


    [Header("Parametrs")]
    public float spawnDelay;
    public int maxSpawnCount = 100;
    public int diamondPerClick;
    public int coinsPerClick;
    public int incomeAmount;

    [Header("Currency")]
    public int coinsCount;
    public int diamondsCount;

    [Header("Skins")]
    public Sprite[] catSkins;
    public int currentSkin = 0;

    private void Awake()
    {
        LoadData();
    }
    private void Update()
    {
        DisplayText();
    }
    private void DisplayText()
    {
        if (coinsCount >= 1000)
        {
            float displayCoin = coinsCount / 1000;
            float afterCoin = (coinsCount % 1000) / 100;
            score.text = $"{displayCoin},{afterCoin}K";
        }
        else
        {
            score.text = coinsCount.ToString();
        }

        diamondText.text = diamondsCount.ToString();
        currentCoinPC.text = "Ќынешнее количество: " + coinsPerClick.ToString();
        currentRespawn.text = "Ќынешн€€ скорость: " + spawnDelay.ToString();
        currentIncome.text = "Ќынешний доход: " + incomeAmount.ToString();
    } 
    private void LoadData()
    {
        if (PlayerPrefs.HasKey("CoinsPerClick"))
            coinsPerClick = PlayerPrefs.GetInt("CoinsPerClick");

        if (PlayerPrefs.HasKey("SpawnDelay"))
            spawnDelay = PlayerPrefs.GetFloat("SpawnDelay");

        if (PlayerPrefs.HasKey("Coins"))
            coinsCount = PlayerPrefs.GetInt("Coins");

        if (PlayerPrefs.HasKey("Diamond"))
            diamondsCount = PlayerPrefs.GetInt("Diamond");

        if (PlayerPrefs.HasKey("Income"))
            incomeAmount = PlayerPrefs.GetInt("Income");

        if (PlayerPrefs.HasKey("CurrentSkin"))
            currentSkin = PlayerPrefs.GetInt("CurrentSkin");
    }
}
