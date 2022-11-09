using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool gameOver = false;
    public float cooldownShot = 1f;
    public GameObject projectile;
    public float horizontalInput;
    public float speed = 10f;
    private float xRange = 9.5f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f, 1f, -9.6f);
    }

    // Update is called once per frame
    void Update()
    {

        //player bounds//
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        //player controls//
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        cooldownShot -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && cooldownShot <= 0)
        {
            Instantiate(projectile, transform.position, transform.rotation);
            cooldownShot = 1f;
        }
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject)  
        {
            Time.timeScale = 0;
        }

        if (collision.gameObject.tag == "Floater")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

       else if (collision.gameObject.tag == "E_Projectile")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

       else if (collision.gameObject.tag == "Shooter")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

       
    }
}
