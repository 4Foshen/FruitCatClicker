using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCats : MonoBehaviour
{
    private PlayerStats stats;

    [SerializeField] private GameObject regularCat; 
    [SerializeField] private GameObject megaCat;
    [SerializeField] private GameObject diamondCat;

    [Header("Coordinates")]
    [SerializeField] private float leftX = -10f;
    [SerializeField] private float rightX = 10f;
    [SerializeField] private float upY = 1f;
    [SerializeField] private float downY = 5f;

    private float lastSpawnTime = 0f;
    private int spawnCount = 0;

    private float randomX;
    private float randomY;

    private float lastDiamondCatSpawnTime = 0f;
    [Header("DiamondCat")]
    [SerializeField] private float diamondCatSpawnInterval = 300f;

    private void Awake()
    {
        stats = FindObjectOfType<PlayerStats>();

        SpawnObject();
    }

    private void Update()
    {
        if (Time.time - lastSpawnTime >= stats.spawnDelay)
        {
            SpawnObject();
            lastSpawnTime = Time.time;
        }

        if (Time.time - lastDiamondCatSpawnTime >= diamondCatSpawnInterval)
        {
            SpawnDiamondCat();
            lastDiamondCatSpawnTime = Time.time;
        }
    }

    private void SpawnObject()
    {
        if (transform.childCount < stats.maxSpawnCount)
        {
            randomX = Random.Range(leftX, rightX);
            randomY = Random.Range(upY, downY);

            Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);

            if (spawnCount != 0 && spawnCount % 10 == 0)
            {
                Instantiate(megaCat, spawnPosition, Quaternion.identity, transform);
            }
            else
            {
                Instantiate(regularCat, spawnPosition, Quaternion.identity, transform);
            }

            spawnCount++;
        }
    }

    private void SpawnDiamondCat()
    {
        if (transform.childCount < stats.maxSpawnCount)
        {
            randomX = Random.Range(leftX, rightX);
            randomY = Random.Range(upY, downY);

            Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);

            Instantiate(diamondCat, spawnPosition, Quaternion.identity, transform);
        }
    }

    private void OnDestroy()
    {
        gameObject.SetActive(false);
    }
}








