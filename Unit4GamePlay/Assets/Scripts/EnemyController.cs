using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField] private float speed = 3f;

    private GameObject _player;

    private Vector3 _movePosition;
    
    

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>().gameObject;
    }

    private void Update()
    {
        _movePosition = (_player.transform.position - transform.position).normalized;
        _rigidbody.AddForce(_movePosition *speed);

        if (transform.position.y<=-2f)
        {
            Destroy(gameObject);
        }
    }
}
