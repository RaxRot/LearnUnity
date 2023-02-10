using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 45f;
    private float _xAxis;
    
    private void Update()
    {
        _xAxis = Input.GetAxis(TagManager.HORIZONTAL_AXIS);
        transform.Rotate(Vector3.up,_xAxis*rotateSpeed*Time.deltaTime);
    }
}
