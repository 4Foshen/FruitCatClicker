using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncomeShop : MonoBehaviour
{
    private PlayerStats _playerStats;
    [SerializeField] private int _minerPrice;
    [SerializeField] private int _progPrice;
    [SerializeField] private int _floppaPrice;
    [SerializeField] private Text _minerPriceText;
    [SerializeField] private Text _progPriceText;
    [SerializeField] private Text _floppaPriceText;
    [Header("Objects")]
    [SerializeField] private GameObject _minerObject;
    [SerializeField] private GameObject _progObject;
    [SerializeField] private GameObject _floppaObject;
    

    private void Awake()
    {
        _playerStats = FindObjectOfType<PlayerStats>();

        LoadData();
    }
    private void Update()
    {
        UpdateText(_minerPrice, _minerPriceText);
        UpdateText(_progPrice, _progPriceText);
        UpdateText(_floppaPrice, _floppaPriceText);
    }
    public void BuyMiner()
    {
        if(_playerStats.coinsCount >= _minerPrice)
        {
            _playerStats.coinsCount -= _minerPrice;
            _playerStats.incomeAmount += 1;
            _minerPrice *= 3;

            _minerObject.SetActive(true);

            PlayerPrefs.SetInt("MinerPrice", _minerPrice);
            PlayerPrefs.SetInt("Income", _playerStats.incomeAmount);
        }
    }
    public void BuyProg()
    {
        if (_playerStats.coinsCount >= _progPrice)
        {
            _playerStats.coinsCount -= _progPrice;
            _playerStats.incomeAmount += 10;
            _progPrice *= 3;

            _progObject.SetActive(true);

            PlayerPrefs.SetInt("ProgPrice", _progPrice);
            PlayerPrefs.SetInt("Income", _playerStats.incomeAmount);
        }
    }
    public void BuyFloppa()
    {
        if (_playerStats.coinsCount >= _floppaPrice)
        {
            _playerStats.coinsCount -= _floppaPrice;
            _playerStats.incomeAmount += 100;
            _floppaPrice *= 3;

            _floppaObject.SetActive(true);

            PlayerPrefs.SetInt("FloppaPrice", _floppaPrice);
            PlayerPrefs.SetInt("Income", _playerStats.incomeAmount);
        }
    }
    private void LoadData()
    {
        if (PlayerPrefs.HasKey("MinerPrice"))
        {
            _minerPrice = PlayerPrefs.GetInt("MinerPrice");
            _minerObject.SetActive(true);
        }

        if (PlayerPrefs.HasKey("ProgPrice"))
        {
            _progPrice = PlayerPrefs.GetInt("ProgPrice");
            _progObject.SetActive(true);
        }

        if (PlayerPrefs.HasKey("FloppaPrice"))
        {
            _floppaPrice = PlayerPrefs.GetInt("FloppaPrice");
            _floppaObject.SetActive(true);
        }
    }
    private void UpdateText(int number, Text priceText)
    {
        if (number >= 1000)
        {
            float displayCoin = number / 1000;
            float afterCoin = (number % 1000) / 100;
            priceText.text = $"{displayCoin},{afterCoin}K";
        }
        else priceText.text = number.ToString();
    }
}
