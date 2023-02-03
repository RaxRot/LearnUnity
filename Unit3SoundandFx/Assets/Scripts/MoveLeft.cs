using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    
    [SerializeField]private float leftBound=-15f;

    private PlayerController _playerController;

    private void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (_playerController.GameOver==false)
        {
            transform.Translate(Vector3.left*Time.deltaTime * speed);
        }

        if (transform.position.x<leftBound && gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
