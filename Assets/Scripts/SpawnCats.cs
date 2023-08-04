using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCats : MonoBehaviour
{
        [SerializeField] private GameObject objectPrefab; 
        [SerializeField] private int maxSpawnCount = 100;   
        [SerializeField] private float spawnDelay = 5f;  

        private int currentSpawnCount = 0; 
        private float lastSpawnTime = 0f;

        private float randomX;
        private float randomY;

        private void Update()
        {
            if (currentSpawnCount < maxSpawnCount && Time.time - lastSpawnTime >= spawnDelay)
            {
                SpawnObject();
                lastSpawnTime = Time.time;
            }
        }

        private void SpawnObject()
        {
            randomX = Random.Range(-10f, 10f);
            randomY = Random.Range(1f, 5f);    

            Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);

            Instantiate(objectPrefab, spawnPosition, Quaternion.identity);

            currentSpawnCount++;
        }
    }

