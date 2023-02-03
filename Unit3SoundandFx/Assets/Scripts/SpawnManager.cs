using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    private int _index;

    [SerializeField] private float timeBetweenSpawnObstacle = 6f;

    private PlayerController _playerController;

    private void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        
        StartCoroutine(nameof(_SpawnObstacleCo));
    }

    private void SpawnObstacle()
    {
        _index = Random.Range(0, obstacles.Length);
        Instantiate(obstacles[_index], transform.position, Quaternion.identity);
    }

    private IEnumerator _SpawnObstacleCo()
    {
        if (_playerController.GameOver==false)
        {
            yield return new WaitForSeconds(timeBetweenSpawnObstacle);
            SpawnObstacle();

            StartCoroutine(nameof(_SpawnObstacleCo));
        }
    }
}
