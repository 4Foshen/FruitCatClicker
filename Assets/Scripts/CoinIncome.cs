using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinIncome : MonoBehaviour
{
    private PlayerStats _stats;
    private Coroutine IncomeCoroutine;

    private void Awake()
    {
        _stats = FindObjectOfType<PlayerStats>();
        IncomeCoroutine = StartCoroutine(Income());
    }

    private IEnumerator Income()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            _stats.coinsCount += _stats.incomeAmount;
        }
    }
}
