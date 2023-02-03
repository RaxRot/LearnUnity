using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Animator _anim;
    private AudioSource _audioSource;

    [SerializeField] private float jumpForce = 20f;
    private bool _isGround;
    
    private bool _gameOver;
    public bool GameOver => _gameOver;

    [SerializeField] private ParticleSystem explosionParticle, dirtParticle;
    [SerializeField] private AudioClip jumpSound, crashSound;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }
    
    private void Update()
    {
        ControlPlayer();
    }

    private void ControlPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGround && !_gameOver)
        {
            _rigidbody.AddForce(Vector3.up*jumpForce,ForceMode.Impulse);
            _anim.SetTrigger("Jump_trig");
            _isGround = false;
            dirtParticle.Stop();
            _audioSource.PlayOneShot(jumpSound,1f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            dirtParticle.Play();
            _isGround = true;
        }else if (collision.gameObject.CompareTag("Enemy"))
        {
            dirtParticle.Stop();
            _gameOver = true;
            _anim.SetBool("Death_b",true);
            _anim.SetInteger("DeathType",1);
            explosionParticle.Play();
            print("Game Over");
            _audioSource.PlayOneShot(crashSound,1f);
        }
    }
}
