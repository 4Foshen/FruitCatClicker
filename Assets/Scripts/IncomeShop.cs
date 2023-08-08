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

    private void Awake()
    {
        _playerStats= GetComponent<PlayerStats>();

        LoadData();
    }
    private void Update()
    {
        UpdateText(_minerPrice, _minerPriceText);
        UpdateText(_progPrice, _progPriceText);
        UpdateText(_floppaPrice, _floppaPriceText);
    }
    public void BuyMiner(GameObject minerObject)
    {
        if(_playerStats.coinsCount >= _minerPrice)
        {
            _playerStats.coinsCount -= _minerPrice;
            _playerStats.incomeAmount += 1;
            _minerPrice *= 2;

            PlayerPrefs.SetInt("MinerPrice", _minerPrice);
        }
    }
    public void BuyProg(GameObject minerObject)
    {
        if (_playerStats.coinsCount >= _progPrice)
        {
            _playerStats.coinsCount -= _progPrice;
            _playerStats.incomeAmount += 10;
            _progPrice *= 2;

            PlayerPrefs.SetInt("ProgPrice", _progPrice);
        }
    }
    public void BuyFloppa(GameObject minerObject)
    {
        if (_playerStats.coinsCount >= _floppaPrice)
        {
            _playerStats.coinsCount -= _floppaPrice;
            _playerStats.incomeAmount += 100;
            _floppaPrice *= 2;

            PlayerPrefs.SetInt("FloppaPrice", _floppaPrice);
        }
    }
    private void LoadData()
    {
        if (PlayerPrefs.HasKey("MinerPrice"))
            _minerPrice = PlayerPrefs.GetInt("MinerPrice");
        else
            _minerPrice = 10;

        if (PlayerPrefs.HasKey("ProgPrice"))
            _progPrice = PlayerPrefs.GetInt("ProgPrice");
        else
            _progPrice = 100;

        if (PlayerPrefs.HasKey("FloppaPrice"))
            _floppaPrice = PlayerPrefs.GetInt("FloppaPrice");
        else
            _floppaPrice = 1000;
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
