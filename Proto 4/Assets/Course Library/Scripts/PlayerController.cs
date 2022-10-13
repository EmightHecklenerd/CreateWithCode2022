using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject powerupIndicator;
    private GameObject focalPoint;
    private Rigidbody playerRb;

    private float powerupStrength = 15.0f;
    public float speed = 5f;
    public bool hasPowerUp;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
            if (other.CompareTag("PowerUp"))
            {
                hasPowerUp = true;
                Destroy(other.gameObject);
                StartCoroutine(PowerUpCountdownRoutine());
                powerupIndicator.gameObject.SetActive(true);
            }
    }

    IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
        Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Debug.Log("Collided with " + collision.gameObject.name
                + "with powerup set to " + hasPowerUp);
            enemyRigidBody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }
    


    
}
