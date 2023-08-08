using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class MegaCatHealth : MonoBehaviour
{
    private PlayerStats stats;
    private int maxHealth = 5;
    private int currentHealth;
    private int damage = 1;

    private void Start()
    {
        stats = FindObjectOfType<PlayerStats>();
        
        currentHealth = maxHealth;
    }
    private void Update()
    {
       
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            HandleTouch(Input.GetTouch(0).position);
        }

    }
    private void OnMouseDown()
    {
        HandleTouch(Input.mousePosition);
    }

    private void HandleTouch(Vector2 touchPosition)
    {
        
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);
  
        Collider2D hitCollider = Physics2D.OverlapPoint(worldPosition);

        if (hitCollider != null && hitCollider.gameObject.CompareTag("MegaCats"))
        {
            TakeDamage(damage);
        }
    }
    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
            EarnCoin();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void EarnCoin()
    {
        stats.coinsCount += stats.coinsPerClick * 2;
        PlayerPrefs.SetInt("Coins", stats.coinsCount);
    }

}
