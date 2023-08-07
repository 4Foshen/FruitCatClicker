using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Text score;
    public float spawnDelay;
    public int maxSpawnCount;
    public int coinsPerClick;
    public int coinsCount;
    public int incomeAmount;

    [Header("Skins")]
    public Sprite[] _catSkins;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("CoinsPerClick"))
            coinsPerClick = PlayerPrefs.GetInt("CoinsPerClick");
        else
            coinsPerClick = 1;

        if (PlayerPrefs.HasKey("SpawnDelay"))
            spawnDelay = PlayerPrefs.GetFloat("SpawnDelay");
        else
            spawnDelay = 3f;

        if (PlayerPrefs.HasKey("Coins"))
            coinsCount = PlayerPrefs.GetInt("Coins");
        else
            coinsCount = 0;

        maxSpawnCount = 100;
        incomeAmount = 0;
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
    }
}
