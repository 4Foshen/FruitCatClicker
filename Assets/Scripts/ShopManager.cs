using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    private PlayerStats _stats;

    [Header("Upgrade Shop")]
    [SerializeField] private int _coinUpgradePrice;
    [SerializeField] private int _respawnUpgradePrice;
    [SerializeField] private Text _coinUpgradeText;
    [SerializeField] private Text _respawnUpgradeText;
    
    //system prokachki incom

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
            _respawnUpgradePrice *= 2;

            PlayerPrefs.SetFloat("SpawnDelay", _stats.spawnDelay);
            PlayerPrefs.SetInt("RespawnUpgradePrice", _respawnUpgradePrice);

            Debug.Log(_stats.spawnDelay);
        }
    }
    private void UpdateText()
    {
        _coinUpgradeText.text = "+Монет за клик: " + _coinUpgradePrice.ToString();
        _respawnUpgradeText.text = "+Скорость респавна: " + _respawnUpgradePrice.ToString();
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
