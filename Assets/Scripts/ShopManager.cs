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


    [Header("Skin Shop")]
    [SerializeField] private GameObject[] _buyButtons;
    [SerializeField] private GameObject[] _selectButtons;

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
            _stats.coinsPerClick += 1;
            _coinUpgradePrice *= 2;

            PlayerPrefs.SetInt("CoinsPerClick", _stats.coinsPerClick);
            PlayerPrefs.SetInt("CoinUpgradePrice", _coinUpgradePrice);

            Debug.Log(_stats.coinsPerClick);
        }
    }
    public void RespawnUpgrade()
    {
        if(_stats.coinsCount >= _respawnUpgradePrice && _stats.spawnDelay > 0.5f)
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
    public void BuyOrange(int price)
    {
        if(_stats.diamondsCount >= price)
        {
            _stats.diamondsCount -= price;
            _buyButtons[1].SetActive(false);
            _selectButtons[1].SetActive(true);

            PlayerPrefs.SetInt("OrangeSkin", 1);
        }
    }
    public void BuyBanana(int price)
    {
        if (_stats.diamondsCount >= price)
        {
            _stats.diamondsCount -= price;
            _buyButtons[2].SetActive(false);
            _selectButtons[2].SetActive(true);

            PlayerPrefs.SetInt("BananaSkin", 1);
        }
    }
    public void BuyOnePiece(int price)
    {
        if (_stats.diamondsCount >= price)
        {
            _stats.diamondsCount -= price;
            _buyButtons[3].SetActive(false);
            _selectButtons[3].SetActive(true);

            PlayerPrefs.SetInt("OnePieceSkin", 1);
        }
    }
    public void BuyBaursak(int price)
    {
        if (_stats.diamondsCount >= price)
        {
            _stats.diamondsCount -= price;
            _buyButtons[4].SetActive(false);
            _selectButtons[4].SetActive(true);

            PlayerPrefs.SetInt("BaursakSkin", 1);
        }
    }

    public void SelectSkin(int skinIndex)
    {
        _stats.currentSkin = skinIndex;
        PlayerPrefs.SetInt("CurrentSkin", skinIndex);
    }

    private void LoadData()
    {
        if (PlayerPrefs.HasKey("CoinUpgradePrice"))
            _coinUpgradePrice = PlayerPrefs.GetInt("CoinUpgradePrice");

        if (PlayerPrefs.HasKey("RespawnUpgradePrice"))
            _respawnUpgradePrice = PlayerPrefs.GetInt("RespawnUpgradePrice");

        if (PlayerPrefs.HasKey("OrangeSkin"))
        {
            _selectButtons[1].SetActive(true);
            _buyButtons[1].SetActive(false);
        }
        if (PlayerPrefs.HasKey("BananaSkin"))
        {
            _selectButtons[2].SetActive(true);
            _buyButtons[2].SetActive(false);
        }
        if (PlayerPrefs.HasKey("OnePieceSkin"))
        {
            _selectButtons[3].SetActive(true);
            _buyButtons[3].SetActive(false);
        }
        if (PlayerPrefs.HasKey("BaursakSkin"))
        {
            _selectButtons[4].SetActive(true);
            _buyButtons[4].SetActive(false);
        }
    }
}
