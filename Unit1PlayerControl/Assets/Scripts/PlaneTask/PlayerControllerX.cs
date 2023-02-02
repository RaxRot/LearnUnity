using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField]private float rotationSpeed;
    
    private float _verticalInput;
    
    private void Update()
    {
        // get the user's vertical input
        _verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed*Time.deltaTime);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.right ,-_verticalInput* rotationSpeed * Time.deltaTime);
    }
}
