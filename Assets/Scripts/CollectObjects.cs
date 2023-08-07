using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class CollectObjects : MonoBehaviour
{
    private PlayerStats stats;
    private void Awake()
    {
        stats = FindObjectOfType<PlayerStats>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Vector3 inputPosition = Vector3.zero;

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                inputPosition = touch.position;
            }
            else if (Input.GetMouseButtonDown(0))
            {
                inputPosition = Input.mousePosition;
            }

            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(inputPosition);
            RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("Cats"))
            {
                Destroy(hit.collider.gameObject);
               //PlayerPrefs.SetInt("Coins", stats.coinsCount += stats.coinsPerClick);
                EarnCoin();
            }
        }
    }
    private void EarnCoin()
    {
        stats.coinsCount += stats.coinsPerClick;
        PlayerPrefs.SetInt("Coins", stats.coinsCount);
    }
} 

