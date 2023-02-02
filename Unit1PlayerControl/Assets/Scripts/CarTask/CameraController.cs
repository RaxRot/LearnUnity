using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform _target;
    
    [SerializeField] private Vector3 offset = new Vector3(0, 6, -10);

    private void Awake()
    {
        _target = FindObjectOfType<PlayerController>().transform;
    }

    private void LateUpdate()
    {
        transform.position = _target.position + offset;
    }
}
