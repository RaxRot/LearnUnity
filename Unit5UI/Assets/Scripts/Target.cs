using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField] private float minPushForce =12f, maxPushForce=17f;
    [SerializeField] private float torqueForce = 10f;
    [SerializeField] private float xRange = 4f, ySpawnPos = -6f;

    private GameManager _gameManager;

    [SerializeField] private int minScoreForDestroy = 1, maxScoreForDestroy = 3;

    [SerializeField] private List<GameObject> explosionParticles;
    private int _indexToExplode;

    private const string BadTag = "Bad";
    
    
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        MakePush();

        _gameManager = FindObjectOfType<GameManager>();
    }

    private void MakePush()
    {
        _rigidbody.AddForce(RandomForce(),ForceMode.Impulse);
        _rigidbody.AddTorque(RandomTorque(),RandomTorque(),RandomTorque(),ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }

    private Vector3 RandomForce()
    {
        return Vector3.up*Random.Range(minPushForce,maxPushForce);
    }

    private float RandomTorque()
    {
        return Random.Range(-torqueForce, torqueForce);
    }

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    private void OnMouseDown()
    {
        if (!_gameManager.isGameActive) return;
        
        if (gameObject.transform.CompareTag(BadTag))
        {
            _gameManager.GameOver();
        }
        else
        {
            SpawnFx();

            _gameManager.UpdateScore(Random.Range(minScoreForDestroy,maxScoreForDestroy));
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!gameObject.CompareTag(BadTag))
        {
            _gameManager.GameOver();
        }

        Destroy(gameObject);
    }

    private void SpawnFx()
    {
        _indexToExplode = Random.Range(0, explosionParticles.Count);
        Instantiate(explosionParticles[_indexToExplode], transform.position, Quaternion.identity);
    }
}
