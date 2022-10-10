using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver = false;
    public bool isLowEnough; 

    public float floatForce = 15f;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip boingSound;


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GameObject.Find("Player").GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 8, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 10) isLowEnough = false;
        else isLowEnough = true;
        // While space is pressed and player is low enough, float up
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver && isLowEnough)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }


    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);


        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            Destroy(other.gameObject);
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);

        }

        //ground collision//
        if (other.gameObject.CompareTag("Ground") && !gameOver)
        {
            playerRb.AddForce(Vector3.up * 15, ForceMode.Impulse);
            playerAudio.PlayOneShot(boingSound, 1.0f);

        }

    }

}
