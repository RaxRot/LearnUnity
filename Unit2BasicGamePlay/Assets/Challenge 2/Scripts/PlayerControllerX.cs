using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    [SerializeField] private float moveSpeed = 12f;

    private const string HorizontalInput = "Horizontal";
    private float _xAxis;

    [SerializeField] private float minZ = -17f, maxZ = 17f;

    private Vector3 _temp;
    void Update()
    {
        ControlPlayer();
        
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
    
    private void ControlPlayer()
    {
        _xAxis = Input.GetAxisRaw(HorizontalInput);
        transform.Translate(Vector3.right*(moveSpeed*_xAxis*Time.deltaTime));

        _temp = transform.position;

        if (_temp.z<minZ)
        {
            _temp.z = minZ;
        }

        if (_temp.z>maxZ)
        {
            _temp.z = maxZ;
        }

        transform.position = _temp;
    }
}
