using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;

    private void Update()
    {
        transform.Translate(Vector3.forward*Time.deltaTime*moveSpeed);
    }
}
