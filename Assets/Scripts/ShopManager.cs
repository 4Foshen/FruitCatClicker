using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    private PlayerStats _stats;

    [Header("Upgrade Shop")]
    [SerializeField] private int _coinUpgradePrice;
    [SerializeField] private int _respawnUpgradePrice;
    [SerializeField] private Text _coinUpgradeText;
    [SerializeField] private Text _respawnUpgradeText;
    

    [Header("Income Shop")]
    [SerializeField] private GameObject[] _catWorkers;

    private void Awake()
    {
        _stats = FindObjectOfType<PlayerStats>();

        LoadData();
    }
    private void Update()
    {
        UpdateText();
    }
    public void CoinUpgrade()
    {
        if(_stats.coinsCount >= _coinUpgradePrice)
        {
            _stats.coinsCount -= _coinUpgradePrice;
            _stats.coinsPerClick *= 2;
            _coinUpgradePrice *= 2;

            PlayerPrefs.SetInt("CoinsPerClick", _stats.coinsPerClick);
            PlayerPrefs.SetInt("CoinUpgradePrice", _coinUpgradePrice);

            Debug.Log(_stats.coinsPerClick);
        }
    }
    public void RespawnUpgrade()
    {
        if(_stats.coinsCount >= _respawnUpgradePrice)
        {
            _stats.coinsCount -= _respawnUpgradePrice;
            _stats.spawnDelay -= 0.1f;
            _respawnUpgradePrice *= 3;

            PlayerPrefs.SetFloat("SpawnDelay", _stats.spawnDelay);
            PlayerPrefs.SetInt("RespawnUpgradePrice", _respawnUpgradePrice);

            Debug.Log(_stats.spawnDelay);
        }
    }
    private void UpdateText()
    {
        if (_coinUpgradePrice >= 1000)
        {
            float displayCoin = _coinUpgradePrice / 1000;
            float afterCoin = (_coinUpgradePrice % 1000) / 100;
            _coinUpgradeText.text = $"{displayCoin},{afterCoin}K";
        }
        else _coinUpgradeText.text = _coinUpgradePrice.ToString();

        if(_respawnUpgradePrice >= 1000)
        {
            float displayRespawn = _respawnUpgradePrice / 1000;
            float afterRespawn = (_respawnUpgradePrice % 1000) / 100;
            _respawnUpgradeText.text = $"{displayRespawn},{afterRespawn}K";
        }
        else _respawnUpgradeText.text = _respawnUpgradePrice.ToString();
    }

    private void LoadData()
    {
        if (PlayerPrefs.HasKey("CoinUpgradePrice"))
            _coinUpgradePrice = PlayerPrefs.GetInt("CoinUpgradePrice");
        else
            _coinUpgradePrice = 5;

        if (PlayerPrefs.HasKey("RespawnUpgradePrice"))
            _respawnUpgradePrice = PlayerPrefs.GetInt("RespawnUpgradePrice");
        else
            _respawnUpgradePrice = 20;
    }
}
