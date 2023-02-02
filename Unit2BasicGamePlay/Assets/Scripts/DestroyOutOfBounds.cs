using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField] private float topBoundZ = 30f,lowBoundZ=-10f;

    private void Update()
    {
        if (transform.position.z>topBoundZ)
        {
            Destroy(gameObject);
        }else if (transform.position.z<lowBoundZ)
        {
            Destroy(gameObject);
            print("Game Over");
        }
    }
}
