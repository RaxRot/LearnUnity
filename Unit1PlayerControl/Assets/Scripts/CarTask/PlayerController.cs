using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed = 15f;
    [SerializeField] private float turnSpeed = 25f;

    private const string HorizontalInput = "Horizontal";
    private const string ForwardInput = "Vertical";
    private float _xAxis,_zAxis;

    void Update()
    {
       ControllCar();
    }

    private void ControllCar()
    {
        _zAxis = Input.GetAxis(ForwardInput);
        _xAxis = Input.GetAxis(HorizontalInput);
        
        transform.Translate(Vector3.forward*(Time.deltaTime*moveSpeed*_zAxis));
        transform.Rotate(Vector3.up,Time.deltaTime*turnSpeed*_xAxis);
    }
}
