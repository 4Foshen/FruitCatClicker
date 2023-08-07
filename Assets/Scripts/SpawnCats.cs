using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCats : MonoBehaviour
{
    private PlayerStats stats;

    [SerializeField] private GameObject objectPrefab;

    [Header("Coordinates")]
    [SerializeField] private float leftX = -10f;
    [SerializeField] private float rightX = 10f;
    [SerializeField] private float upY = 1f;
    [SerializeField] private float downY = 5f;

    private float lastSpawnTime = 0f;

    private float randomX;
    private float randomY;

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
    }

    private void SpawnObject()
    {
        if (transform.childCount < stats.maxSpawnCount)
        {
            randomX = Random.Range(leftX, rightX);
            randomY = Random.Range(upY, downY);

            Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);

            Instantiate(objectPrefab, spawnPosition, Quaternion.identity, transform);
        }
    }

    private void OnDestroy()
    {
        gameObject.SetActive(false);
    }
}

