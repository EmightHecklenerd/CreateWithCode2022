using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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


    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject launchedObject = Instantiate(projectile, transform.position, transform.rotation);
            launchedObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, 950f));

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floater")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "E_Projectile")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Shooter")
        {
            Destroy(gameObject);
        }
    }
}
