using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField] private float playerSpeed = 5f;
    private float _zAxis;

    private GameObject _focalPoint;

    [SerializeField] private bool hasPowerUp;

    [SerializeField] private float powerUpStrength = 10f;

    [SerializeField] private GameObject powerUpIndicator;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _focalPoint = FindObjectOfType<RotateCamera>().gameObject;
    }

    private void Update()
    {
        _zAxis = Input.GetAxis(TagManager.VERTICAL_AXIS);
        _rigidbody.AddForce(_focalPoint.transform.forward*_zAxis*playerSpeed);
        powerUpIndicator.transform.position = transform.position - new Vector3(0f, 0.5f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagManager.POWER_UP))
        {
            Destroy(other.gameObject);
            PowerUp();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(TagManager.ENEMY_TAG) && hasPowerUp)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRb.AddForce(awayFromPlayer*powerUpStrength,ForceMode.Impulse);
        }
    }

    private void PowerUp()
    {
        StartCoroutine("_PowerUpCo");
    }
    private IEnumerator _PowerUpCo()
    {
        powerUpIndicator.SetActive(true);
        hasPowerUp = true;
        yield return new WaitForSeconds(7f);
        powerUpIndicator.SetActive(false);
        hasPowerUp = false;
    }
}
