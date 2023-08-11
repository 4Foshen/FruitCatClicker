using System.Collections;
using System.Collections.Generic;
using YG;
using UnityEngine;
using YG.Example;

public class AdManager : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;
    private void Start()
    {
        StartCoroutine(ShowAd());
    }
    private void OnEnable() => YandexGame.RewardVideoEvent += Rewarded;

    private void OnDisable() => YandexGame.RewardVideoEvent -= Rewarded;

    public void Rewarded(int id)
    {
        // ���� ID = 1, �� ����� "+500 �����"
        if (id == 1)
            AddMoney();

        // ���� ID = 2, �� ����� "������".
        else if (id == 2)
            AddDiamond();
    }

    public void OpenRewardAd(int id)
    {
        // �������� ����� �������� ����� �������
        YandexGame.RewVideoShow(id);
    }

    public void AddMoney()
    {
        _playerStats.coinsCount += 500;
    }
    public void AddDiamond()
    {
        _playerStats.diamondsCount += 10;
    }
    public IEnumerator ShowAd()
    {
        while (true)
        {
            yield return new WaitForSeconds(180f);
            YandexGame.FullscreenShow();
        }
    }
}
