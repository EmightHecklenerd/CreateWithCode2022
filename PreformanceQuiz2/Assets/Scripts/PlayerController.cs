using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10f;
    private float xRange = 9.5f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f, 1f, 9.6f);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        //player bounds//
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.x);
        }
        else if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.x);
        }

        //player controls//
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
    }
}
