using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float randomXZRange = 8f;
    private float _xPosition, _zPosition;
    private Vector3 _spawnPosition;

    [SerializeField] private int enemyToSpawn = 1;
    
    [SerializeField] private int enemyCount;

    [SerializeField] private GameObject powerUp;

    private void Start()
    {
      SpawnEnemyWave(enemyToSpawn);
    }

    private void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;

        if (enemyCount<=0)
        {
            enemyToSpawn++;
            SpawnEnemyWave(enemyToSpawn);
            Instantiate(powerUp, GenerateSpawnPoint(), powerUp.transform.rotation);
        }
    }

    private void SpawnEnemyWave(int enemySpawnCount)
    {
        for (int i = 0; i < enemySpawnCount; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPoint(), enemyPrefab.transform.rotation);
        }
    }
    
    private Vector3 GenerateSpawnPoint()
    {
        _xPosition = Random.Range(-randomXZRange, randomXZRange);
        _zPosition = Random.Range(-randomXZRange, randomXZRange);
        _spawnPosition = new Vector3(_xPosition, 0f, _zPosition);

        return _spawnPosition;
    }
}
