using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    [SerializeField] private Vector3 offset=new Vector3(30,4,10);
    
    private void LateUpdate()
    {
        transform.position = plane.transform.position + offset;
    }
}
