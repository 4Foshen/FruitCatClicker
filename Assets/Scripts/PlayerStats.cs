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

    private void Awake()
    {
        coinsPerClick = 5;
        spawnDelay = 3f;
        maxSpawnCount = 10;
        coinsCount = PlayerPrefs.GetInt("Coins");
    }

    private void Update()
    {
        score.text = coinsCount.ToString();
    }
}
