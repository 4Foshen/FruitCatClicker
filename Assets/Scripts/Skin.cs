using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skin : MonoBehaviour
{
    private PlayerStats _playerStats;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _playerStats = FindObjectOfType<PlayerStats>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        SetSkin();
    }

    private void SetSkin()
    {
        _spriteRenderer.sprite = _playerStats.catSkins[_playerStats.currentSkin];
    }
}
