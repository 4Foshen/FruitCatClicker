using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCats : MonoBehaviour
{
        [SerializeField] private GameObject objectPrefab; 
        [SerializeField] private int maxSpawnCount;   
        [SerializeField] private float spawnDelay = 5f;

        [Header("Coordinates")]    
        [SerializeField] private float leftX = -10f;
        [SerializeField] private float rightX = 10f;
        [SerializeField] private float upY = 1f;
        [SerializeField] private float downY = 5f;


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
            randomX = Random.Range(leftX, rightX);
            randomY = Random.Range(upY, downY);    

            Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);

            Instantiate(objectPrefab, spawnPosition, Quaternion.identity);

            currentSpawnCount++;
        }
    }

