using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 12f;

    private const string HorizontalInput = "Horizontal";
    private float _xAxis;

    [SerializeField] private float minX = -15f, maxX = 15f;

    private Vector3 _temp;

    [SerializeField] private GameObject pizza;
    

    private void Update()
    {
        ControlPlayer();

        if (Input.GetKeyDown(KeyCode.Space))
        {
          SpawnPizza();  
        }
    }

    private void SpawnPizza()
    {
        Instantiate(pizza, transform.position, pizza.transform.rotation);
    }

    private void ControlPlayer()
    {
        _xAxis = Input.GetAxisRaw(HorizontalInput);
        transform.Translate(Vector3.right*(moveSpeed*_xAxis*Time.deltaTime));

        _temp = transform.position;

        if (_temp.x<minX)
        {
            _temp.x = minX;
        }

        if (_temp.x>maxX)
        {
            _temp.x = maxX;
        }

        transform.position = _temp;
    }
}
